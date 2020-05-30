using CommandLine;
using DbgNet;
using DbgNet.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace dbug
{
    public delegate void LoadDLL(string name);
    public delegate void UnloadDLL(string name);

    public delegate void CreateProcess(string name);
    public delegate void ExitProcess(string name);

    public delegate void CreateThread(string msg);
    public delegate void ExitThread(string msg);

    public delegate void Exception(string msg);

    class Program
    {
        static Options Options;

        static LoadDLL LoadDLL = (_) => { };
        static UnloadDLL UnloadDLL = (_) => { };

        static CreateProcess CreateProcess = (_) => { };
        static ExitProcess ExitProcess = (_) => { };

        static CreateThread CreateThread = (_) => { };
        static ExitThread ExitThread = (_) => { };

        static Exception Exception = (_) => { };

        static PROCESS_INFORMATION pInfo;

        static void Main(string[] args)
        {

            const int DLLPATH_BUFFER_SIZE = 2048;
            DEBUG_EVENT EVENT;
            uint WAITFOR_MS = (uint)TimeSpan.FromMilliseconds(5).TotalMilliseconds;
            bool ERROR = true;
            int ERROR_CODE = -1;
            bool OK = false;
            ContinueStatus DBG_CONTINUE_NEXT_STATUS = ContinueStatus.DBG_CONTINUE;
            StringBuilder sb = new StringBuilder(DLLPATH_BUFFER_SIZE);
            Dictionary<IntPtr, string> LoadedDlls = new Dictionary<IntPtr, string>();

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opt =>
                {
                    pInfo = NativeHelpers.CreateProcess(
                        applicationName: null,
                        commandLine: opt.Process,
                        flags: CreateProcessFlags.DEBUG_PROCESS | CreateProcessFlags.DETACHED_PROCESS
                    );

                    if (opt.LoadDLL) LoadDLL += Console.WriteLine;
                    if (opt.UnloadDLL) UnloadDLL += Console.WriteLine;
                    
                    if (opt.CreateProcess) CreateProcess += Console.WriteLine;
                    if (opt.ExitProcess) ExitProcess += Console.WriteLine;

                    if (opt.CreateThread) CreateThread += Console.WriteLine;
                    if (opt.ExitThread) ExitThread += Console.WriteLine;

                    if (opt.Exception) Exception += Console.WriteLine;


                });

            Process debuggee = Process.GetProcessById(pInfo.dwProcessId);
            Console.WriteLine($@"{debuggee.ProcessName} started for debugging: PID: {pInfo.dwProcessId}");




            do
            {
                ERROR = NativeMethods.WaitForDebugEvent(out EVENT, WAITFOR_MS);
                DBG_CONTINUE_NEXT_STATUS = ContinueStatus.DBG_CONTINUE;

                switch (EVENT.dwDebugEventCode)
                {
                    case DebugEventType.NONE:
                        break;
                    case DebugEventType.RIP_EVENT:
                        break;
                    case DebugEventType.OUTPUT_DEBUG_STRING_EVENT:
                        byte[] buffer = EVENT.DebugString.nDebugStringLength != decimal.Zero
                            ? new byte[EVENT.DebugString.nDebugStringLength - 1]
                            : new byte[DLLPATH_BUFFER_SIZE];

                        IntPtr bytesReadPtr = IntPtr.Zero;

                        NativeMethods.ReadProcessMemory(
                            debuggee.Handle,
                            EVENT.DebugString.lpDebugStringData,
                            buffer,
                            EVENT.DebugString.nDebugStringLength - 1,
                            out bytesReadPtr);

                        break;
                    case DebugEventType.UNLOAD_DLL_DEBUG_EVENT:
                        UnloadDLL(LoadedDlls[EVENT.UnloadDll.lpBaseOfDll]);
                        break;
                    case DebugEventType.LOAD_DLL_DEBUG_EVENT:

                        NativeMethods.GetFinalPathNameByHandle(EVENT.LoadDll.hFile, sb, DLLPATH_BUFFER_SIZE, FinalPathFlags.FILE_NAME_NORMALIZED);

                        string dllName = sb.ToString();

                        LoadedDlls[EVENT.LoadDll.lpBaseOfDll] = dllName;

                        LoadDLL(dllName);

                        break;
                    case DebugEventType.EXIT_PROCESS_DEBUG_EVENT:
                        ExitProcess($"[PROCESS EXIT] Exit Code:{EVENT.ExitProcess.dwExitCode.ToHex()}");
                        break;
                    case DebugEventType.EXIT_THREAD_DEBUG_EVENT:
                        ExitThread($"[THREAD EXIT] ExitCode: {EVENT.ExitThread.dwExitCode.ToHex()}");
                        break;
                    case DebugEventType.CREATE_PROCESS_DEBUG_EVENT:

                        NativeMethods.GetFinalPathNameByHandle(EVENT.CreateProcessInfo.hFile, sb, DLLPATH_BUFFER_SIZE, FinalPathFlags.FILE_NAME_NORMALIZED);

                        CreateProcess(sb.ToString());
                        break;
                    case DebugEventType.CREATE_THREAD_DEBUG_EVENT:
                        CreateThread($"[THREAD CREATED] {EVENT.CreateThread.hThread.ToHex()}");
                        break;
                    case DebugEventType.EXCEPTION_DEBUG_EVENT:
                        Exception($"[EXCEPTION] First: {EVENT.Exception.dwFirstChance} @ {EVENT.Exception.ExceptionRecord.ExceptionAddress.ToHex()} Code: {EVENT.Exception.ExceptionRecord.ExceptionCode.ToHex()}");
                        DBG_CONTINUE_NEXT_STATUS = ContinueStatus.DBG_EXCEPTION_NOT_HANDLED;
                        break;
                    default:
                        break;

                }

                OK = NativeMethods.ContinueDebugEvent(EVENT.dwProcessId, EVENT.dwThreadId, DBG_CONTINUE_NEXT_STATUS);
                ERROR_CODE = Marshal.GetLastWin32Error();
            } while (true);
        }
    }
}
