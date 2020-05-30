using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DbgNet.Core.NativeMethods;

namespace DbgNet.Core
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

        #endregion


        [DllImport(KERNEL32, SetLastError = true)]
        public static extern uint GetFileSize(IntPtr hFile, out uint lpFileSizeHigh);

        #region WaitForDebugEvent

        [DllImport(KERNEL32, EntryPoint = "WaitForDebugEvent", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WaitForDebugEvent(out DEBUG_EVENT lpDebugEvent, uint dwMilliseconds);

        #endregion


        #region Continue Debug

        [DllImport(KERNEL32, SetLastError = true)]
        public static extern bool ContinueDebugEvent(int dwProcessId, int dwThreadId, ContinueStatus dwContinueStatus);

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


        [DllImport(KERNEL32, SetLastError = true)]
        public static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject,
           FileMapAccessType dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow,
           uint dwNumberOfBytesToMap);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern uint GetMappedFileName(IntPtr hProcess,
            IntPtr lpv,
            out StringBuilder lpFilename,
            uint nSize);
    }

    public delegate uint PTHREAD_START_ROUTINE(IntPtr lpThreadParameter);
}
