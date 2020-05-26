using SimpleDebugger;
using System;
using System.Runtime.InteropServices;
using static SimpleDebugger.NativeMethods;

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