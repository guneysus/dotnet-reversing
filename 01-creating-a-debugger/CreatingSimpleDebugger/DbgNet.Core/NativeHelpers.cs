using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DbgNet.Core.NativeMethods;

namespace DbgNet.Core
{

    public static class NativeHelpers
    {

        public static PROCESS_INFORMATION CreateProcess(string applicationName, string commandLine, CreateProcessFlags flags)
        {
            bool retValue;
            STARTUPINFO sInfo = new STARTUPINFO();
            SECURITY_ATTRIBUTES pSec = new SECURITY_ATTRIBUTES();
            SECURITY_ATTRIBUTES tSec = new SECURITY_ATTRIBUTES();
            pSec.nLength = Marshal.SizeOf(pSec);
            tSec.nLength = Marshal.SizeOf(tSec);
            PROCESS_INFORMATION pInfo;
            retValue = NativeMethods.CreateProcess(
                lpApplicationName: applicationName,
                lpCommandLine: commandLine,
                lpProcessAttributes: ref pSec,
                lpThreadAttributes: ref tSec,
                bInheritHandles: false,
                dwCreationFlags: flags,
                lpEnvironment: IntPtr.Zero,
                lpCurrentDirectory: null,
                lpStartupInfo: ref sInfo,
                lpProcessInformation: out pInfo);

            return pInfo;
        }

    }
}
