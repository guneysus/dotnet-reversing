using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SimpleDebugger.NativeMethods;

namespace SimpleDebugger
{
    public static class NativeMethods
    {
        private const string KERNEL32 = "kernel32.dll";

        [DllImport(KERNEL32, SetLastError = true)]
        public static extern bool DebugActiveProcess(int dwProcessId);

        #region Create Process
        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CreateProcess(string lpApplicationName,
                                                string lpCommandLine,
                                                ref SECURITY_ATTRIBUTES lpProcessAttributes,
                                                ref SECURITY_ATTRIBUTES lpThreadAttributes,
                                                bool bInheritHandles,
                                                CreateProcessFlags dwCreationFlags,
                                                IntPtr lpEnvironment,
                                                string lpCurrentDirectory,
                                                [In] ref STARTUPINFO lpStartupInfo,
                                                out PROCESS_INFORMATION lpProcessInformation);

        [DllImport(KERNEL32, SetLastError = true)]
        public static extern bool CheckRemoteDebuggerPresent(
            IntPtr hProcess,
            out bool pbDebuggerPresent);

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct STARTUPINFOEX
        {
            public STARTUPINFO StartupInfo;
            public IntPtr lpAttributeList;
        }

        // If you are using this with [GetStartupInfo], this definition works without errors.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public IntPtr lpReserved;
            public IntPtr lpDesktop;
            public IntPtr lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwYSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        [Flags]
        public enum CreateProcessFlags : uint
        {
            DEBUG_PROCESS = 0x00000001,
            DEBUG_ONLY_THIS_PROCESS = 0x00000002,
            CREATE_SUSPENDED = 0x00000004,
            DETACHED_PROCESS = 0x00000008,
            CREATE_NEW_CONSOLE = 0x00000010,
            NORMAL_PRIORITY_CLASS = 0x00000020,
            IDLE_PRIORITY_CLASS = 0x00000040,
            HIGH_PRIORITY_CLASS = 0x00000080,
            REALTIME_PRIORITY_CLASS = 0x00000100,
            CREATE_NEW_PROCESS_GROUP = 0x00000200,
            CREATE_UNICODE_ENVIRONMENT = 0x00000400,
            CREATE_SEPARATE_WOW_VDM = 0x00000800,
            CREATE_SHARED_WOW_VDM = 0x00001000,
            CREATE_FORCEDOS = 0x00002000,
            BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,
            ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,
            INHERIT_PARENT_AFFINITY = 0x00010000,
            INHERIT_CALLER_PRIORITY = 0x00020000,
            CREATE_PROTECTED_PROCESS = 0x00040000,
            EXTENDED_STARTUPINFO_PRESENT = 0x00080000,
            PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,
            PROCESS_MODE_BACKGROUND_END = 0x00200000,
            CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
            CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
            CREATE_DEFAULT_ERROR_MODE = 0x04000000,
            CREATE_NO_WINDOW = 0x08000000,
            PROFILE_USER = 0x10000000,
            PROFILE_KERNEL = 0x20000000,
            PROFILE_SERVER = 0x40000000,
            CREATE_IGNORE_SYSTEM_DEFAULT = 0x80000000,
        }

        #endregion


        [DllImport(KERNEL32, SetLastError = true)]
        public static extern uint GetFileSize(IntPtr hFile, out uint lpFileSizeHigh);

        #region WaitForDebugEvent

        [DllImport(KERNEL32, EntryPoint = "WaitForDebugEvent", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WaitForDebugEvent(out DEBUG_EVENT lpDebugEvent, uint dwMilliseconds);


        public enum DebugEventType : uint
        {
            NONE = 0,
            RIP_EVENT = 9,
            OUTPUT_DEBUG_STRING_EVENT = 8,
            UNLOAD_DLL_DEBUG_EVENT = 7,
            LOAD_DLL_DEBUG_EVENT = 6,
            EXIT_PROCESS_DEBUG_EVENT = 5,
            EXIT_THREAD_DEBUG_EVENT = 4,
            CREATE_PROCESS_DEBUG_EVENT = 3,
            CREATE_THREAD_DEBUG_EVENT = 2,
            EXCEPTION_DEBUG_EVENT = 1,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DEBUG_EVENT
        {
            public DebugEventType dwDebugEventCode;
            public int dwProcessId;
            public int dwThreadId;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 86, ArraySubType = UnmanagedType.U1)]
            byte[] debugInfo;

            public EXCEPTION_DEBUG_INFO Exception => GetDebugInfo<EXCEPTION_DEBUG_INFO>();

            public CREATE_THREAD_DEBUG_INFO CreateThread => GetDebugInfo<CREATE_THREAD_DEBUG_INFO>();

            public CREATE_PROCESS_DEBUG_INFO CreateProcessInfo => GetDebugInfo<CREATE_PROCESS_DEBUG_INFO>();

            public EXIT_THREAD_DEBUG_INFO ExitThread => GetDebugInfo<EXIT_THREAD_DEBUG_INFO>();

            public EXIT_PROCESS_DEBUG_INFO ExitProcess => GetDebugInfo<EXIT_PROCESS_DEBUG_INFO>();

            public LOAD_DLL_DEBUG_INFO LoadDll => GetDebugInfo<LOAD_DLL_DEBUG_INFO>();

            public UNLOAD_DLL_DEBUG_INFO UnloadDll => GetDebugInfo<UNLOAD_DLL_DEBUG_INFO>();

            public OUTPUT_DEBUG_STRING_INFO DebugString => GetDebugInfo<OUTPUT_DEBUG_STRING_INFO>();

            public RIP_INFO RipInfo => GetDebugInfo<RIP_INFO>();

            private T GetDebugInfo<T>() where T : struct
            {
                var structSize = Marshal.SizeOf(typeof(T));
                var pointer = Marshal.AllocHGlobal(structSize);
                Marshal.Copy(debugInfo, 0, pointer, structSize);

                var result = Marshal.PtrToStructure(pointer, typeof(T));
                Marshal.FreeHGlobal(pointer);
                return (T)result;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EXCEPTION_DEBUG_INFO
        {
            public EXCEPTION_RECORD ExceptionRecord;
            public uint dwFirstChance;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EXCEPTION_RECORD
        {
            public uint ExceptionCode;
            public uint ExceptionFlags;
            public IntPtr ExceptionRecord;
            public IntPtr ExceptionAddress;
            public uint NumberParameters;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.U4)] public uint[] ExceptionInformation;
        }

        public delegate uint PTHREAD_START_ROUTINE(IntPtr lpThreadParameter);

        [StructLayout(LayoutKind.Sequential)]
        public struct CREATE_THREAD_DEBUG_INFO
        {
            public IntPtr hThread;
            public IntPtr lpThreadLocalBase;
            public PTHREAD_START_ROUTINE lpStartAddress;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CREATE_PROCESS_DEBUG_INFO
        {
            public IntPtr hFile;
            public IntPtr hProcess;
            public IntPtr hThread;
            public IntPtr lpBaseOfImage;
            public uint dwDebugInfoFileOffset;
            public uint nDebugInfoSize;
            public IntPtr lpThreadLocalBase;
            /* 
             * TODO
             * http://pinvoke.net/default.aspx/Structures/CREATE_PROCESS_DEBUG_INFO.html
             * public PTHREAD_START_ROUTINE lpStartAddress;
             * 
             */
            public IntPtr lpImageName;
            public ushort fUnicode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EXIT_THREAD_DEBUG_INFO
        {
            public uint dwExitCode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EXIT_PROCESS_DEBUG_INFO
        {
            public uint dwExitCode;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct LOAD_DLL_DEBUG_INFO
        {
            public IntPtr hFile;
            public IntPtr lpBaseOfDll;
            public uint dwDebugInfoFileOffset;
            public uint nDebugInfoSize;
            public IntPtr lpImageName;
            public ushort fUnicode;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UNLOAD_DLL_DEBUG_INFO
        {
            public IntPtr lpBaseOfDll;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OUTPUT_DEBUG_STRING_INFO
        {
            //[MarshalAs(UnmanagedType.LPStr)] public string lpDebugStringData; 

            public IntPtr lpDebugStringData;
            public ushort fUnicode;
            public ushort nDebugStringLength;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RIP_INFO
        {
            public uint dwError;
            public uint dwType;
        }

        #endregion


        #region Continue Debug

        [DllImport(KERNEL32, SetLastError = true)]
        public static extern bool ContinueDebugEvent(int dwProcessId, int dwThreadId, ContinueStatus dwContinueStatus);

        /// <summary>
        /// http://pinvoke.net/default.aspx/kernel32/ContinueStatus.html
        /// </summary>
        public enum ContinueStatus : uint
        {
            DBG_CONTINUE = 0x00010002,
            DBG_EXCEPTION_NOT_HANDLED = 0x80010001,
            DBG_REPLY_LATER = 0x40010001
        }

        #endregion

        #region ReadProcessMemory 
        [DllImport(KERNEL32, SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess,
            IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        #endregion

        #region GetFinalPathNameByHandle
        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint GetFinalPathNameByHandle(IntPtr hFile,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszFilePath,
            uint cchFilePath,
            FinalPathFlags dwFlags);

        [Flags]
        public enum FinalPathFlags : uint
        {
            VOLUME_NAME_DOS = 0x0,
            FILE_NAME_NORMALIZED = 0x0,
            VOLUME_NAME_GUID = 0x1,
            VOLUME_NAME_NT = 0x2,
            VOLUME_NAME_NONE = 0x4,
            FILE_NAME_OPENED = 0x8
        }

        #endregion

        [DllImport(KERNEL32, SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport(KERNEL32, SetLastError = true)]
        public static extern bool GetFileSizeEx(IntPtr hFile, out long lpFileSize);


        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFileMapping(
            IntPtr hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            out string lpName);

        [Flags]
        public enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }


        [DllImport(KERNEL32, SetLastError = true)]
        public static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject,
           FileMapAccessType dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow,
           uint dwNumberOfBytesToMap);

        public enum FileMapAccessType : uint
        {
            Copy = 0x01,
            Write = 0x02,
            Read = 0x04,
            AllAccess = 0x08,
            Execute = 0x20,
        }

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern uint GetMappedFileName(IntPtr hProcess,
            IntPtr lpv,
            out StringBuilder lpFilename,
            uint nSize);
    }
}
