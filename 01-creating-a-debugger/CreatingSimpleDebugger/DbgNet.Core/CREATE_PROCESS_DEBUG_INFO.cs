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

}
