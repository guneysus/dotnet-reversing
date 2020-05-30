using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DbgNet.Core.NativeMethods;

namespace DbgNet.Core
{

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

}
