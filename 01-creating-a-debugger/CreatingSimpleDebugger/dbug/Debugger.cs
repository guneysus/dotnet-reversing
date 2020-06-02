using CommandLine;
using DbgNet;
using DbgNet.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace dbug
{

    public class Debugger
    {
        Process debuggee;

        const int DLLPATH_BUFFER_SIZE = 2048;
        DEBUG_EVENT EVENT;
        uint WAITFOR_MS = (uint)TimeSpan.FromMilliseconds(5).TotalMilliseconds;
        bool ERROR = true;
        int ERROR_CODE = -1;
        bool OK = false;
        ContinueStatus DBG_CONTINUE_NEXT_STATUS = ContinueStatus.DBG_CONTINUE;
        StringBuilder sb = new StringBuilder(DLLPATH_BUFFER_SIZE);
        Dictionary<IntPtr, string> LoadedDlls = new Dictionary<IntPtr, string>();
        Options Options;

        LoadDLL LoadDLL = (_) => { };
        UnloadDLL UnloadDLL = (_) => { };

        CreateProcess CreateProcess = (_) => { };
        ExitProcess ExitProcess = (_) => { };

        internal void Pause()
        {
            //debuggerThread.Abort();
        }

        CreateThread CreateThread = (_) => { };
        ExitThread ExitThread = (_) => { };

        Exception Exception = (_) => { };

        PROCESS_INFORMATION pInfo;
        private readonly Options opt;
        Thread debuggerThread;

        public Debugger(Options options)
        {
            this.opt = options;
        }

        public void Start()
        {
            debuggerThread = new Thread(new ThreadStart(Main))
            {
                IsBackground = true
            };

            debuggerThread.Start();

            do
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "!c":
                        Loop(debuggee);
                        break;
                    case "!b":
                        NativeMethods.DebugBreak();
                        Console.WriteLine($"code: {Marshal.GetLastWin32Error()}"); 
                        break;
                    case "!d":
                        var result = NativeMethods.DebugActiveProcessStop(pInfo.dwProcessId);
                        var code = Marshal.GetLastWin32Error();
                        Console.WriteLine($"{result} code:{code}");
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        public void Main()
        {
            pInfo = NativeHelpers.CreateProcess(
                applicationName:   null,
                commandLine: opt.Process,
                //flags: CreateProcessFlags.DEBUG_ONLY_THIS_PROCESS | CreateProcessFlags.DETACHED_PROCESS
                flags: CreateProcessFlags.DETACHED_PROCESS | CreateProcessFlags.DEBUG_PROCESS
            );

            if (pInfo.dwProcessId == decimal.Zero)
            {
                Environment.Exit(-1);
            }

            var _ = NativeMethods.DebugActiveProcess(pInfo.dwProcessId);
            var code = Marshal.GetLastWin32Error();

            NativeMethods.DebugSetProcessKillOnExit(false);


            if (opt.LoadDLL) LoadDLL += (IntPtr address) =>
            {
                Console.WriteLine($"ModLoad: {address.Address()} {LoadedDlls[address]}");
            };

            if (opt.UnloadDLL) UnloadDLL += (IntPtr address) =>
            {
                Console.WriteLine($"ModUnLoad: {address.Address()} {LoadedDlls[address]}");
            };

            if (opt.CreateProcess) CreateProcess += Console.WriteLine;
            if (opt.ExitProcess) ExitProcess += Console.WriteLine;

            if (opt.CreateThread) CreateThread += Console.WriteLine;
            if (opt.ExitThread) ExitThread += Console.WriteLine;

            if (opt.Exception) Exception += Console.WriteLine;

            debuggee = Process.GetProcessById(pInfo.dwProcessId);
            Console.WriteLine($@"{debuggee.ProcessName} started for debugging: PID: {pInfo.dwProcessId}");

            Loop(debuggee);
        }


        private void Loop(Process debuggee)
        {
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
                        UnloadDLL(EVENT.UnloadDll.lpBaseOfDll);
                        break;
                    case DebugEventType.LOAD_DLL_DEBUG_EVENT:

                        NativeMethods.GetFinalPathNameByHandle(EVENT.LoadDll.hFile, sb, DLLPATH_BUFFER_SIZE, FinalPathFlags.FILE_NAME_NORMALIZED);

                        string dllName = sb.ToString();

                        LoadedDlls[EVENT.LoadDll.lpBaseOfDll] = dllName;

                        LoadDLL(EVENT.LoadDll.lpBaseOfDll);

                        break;
                    case DebugEventType.EXIT_PROCESS_DEBUG_EVENT:
                        ExitProcess($"[PROCESS EXIT] Exit Code:{EVENT.ExitProcess.dwExitCode.Address()}");
                        break;
                    case DebugEventType.EXIT_THREAD_DEBUG_EVENT:
                        ExitThread($"[THREAD EXIT] ExitCode: {EVENT.ExitThread.dwExitCode.Address()}");
                        break;
                    case DebugEventType.CREATE_PROCESS_DEBUG_EVENT:

                        NativeMethods.GetFinalPathNameByHandle(EVENT.CreateProcessInfo.hFile, sb, DLLPATH_BUFFER_SIZE, FinalPathFlags.FILE_NAME_NORMALIZED);
                        CreateProcess($"[PROCESS CREATED] {EVENT.CreateProcessInfo.lpBaseOfImage.Address()} {sb.ToString()}");
                        break;
                    case DebugEventType.CREATE_THREAD_DEBUG_EVENT:
                        CreateThread($"[THREAD CREATED] {EVENT.CreateThread.hThread.Address()}");
                        break;
                    case DebugEventType.EXCEPTION_DEBUG_EVENT:
                        Exception($"[EXCEPTION] First: {EVENT.Exception.dwFirstChance} @ {EVENT.Exception.ExceptionRecord.ExceptionAddress.Address()} Code: {EVENT.Exception.ExceptionRecord.ExceptionCode.Address()}");
                        DBG_CONTINUE_NEXT_STATUS = ContinueStatus.DBG_EXCEPTION_NOT_HANDLED;
                        break;
                    default:
                        break;

                }

                OK = NativeMethods.ContinueDebugEvent(EVENT.dwProcessId, EVENT.dwThreadId, DBG_CONTINUE_NEXT_STATUS);
                ERROR_CODE = Marshal.GetLastWin32Error();
            } while (true);
        }

        public int ProcessId => pInfo.dwProcessId;
    }

}

