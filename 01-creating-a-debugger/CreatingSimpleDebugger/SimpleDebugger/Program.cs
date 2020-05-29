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
    public delegate void DebugLog(string message);

    internal static class Program
    {
        static DebugLog DebuggerLog;
        static Process debuggee;
        static List<DEBUG_EVENT> Events = new List<DEBUG_EVENT>();
        static List<string> Timeline = new List<string>();

        static DEBUG_EVENT EVENT;
        static uint WAITFOR_MS = (uint)TimeSpan.FromSeconds(1).TotalMilliseconds;
        static bool ERROR = true;
        static int ERROR_CODE = -1;
        static bool OK = false;
        static Dictionary<IntPtr, string> LoadedDlls = new Dictionary<IntPtr, string>();


        static void Main(string[] args)
        {
            debuggee = StartDebuggee(CreateProcessFlags.DEBUG_ONLY_THIS_PROCESS);

            DebuggerLog += (msg) =>
            {
                Console.Write(msg);
            };

            while (true)
            {
                Prompt();
                CommandLoop();
            }
        }

        public static string EventString(DEBUG_EVENT evt)
        {
            string log = null;

            switch (evt.dwDebugEventCode)
            {
                case DebugEventType.RIP_EVENT:
                    log = ProcessRipEvent(evt);
                    break;
                case DebugEventType.OUTPUT_DEBUG_STRING_EVENT:
                    log = ProcessOutputDebugStringEvent(evt);
                    break;
                case DebugEventType.UNLOAD_DLL_DEBUG_EVENT:
                    log = ProcessUnloadDllDebugEvent(evt);
                    break;
                case DebugEventType.LOAD_DLL_DEBUG_EVENT:
                    log = ProcessLoadDLLEvent(evt);
                    break;
                case DebugEventType.EXIT_PROCESS_DEBUG_EVENT:
                    log = ProcessExitProcessEvent(evt);
                    break;
                case DebugEventType.EXIT_THREAD_DEBUG_EVENT:
                    log = ProcessExitThreadEvent(evt);
                    break;
                case DebugEventType.CREATE_PROCESS_DEBUG_EVENT:
                    log = ProcessCreateProcessEvent(evt);
                    break;
                case DebugEventType.CREATE_THREAD_DEBUG_EVENT:
                    log = ProcessCreateThreadEvent(evt);
                    break;
                case DebugEventType.EXCEPTION_DEBUG_EVENT:
                    log = ProcessExceptionDebugEvent(evt);
                    break;
                default:
                    break;
            }

            return log;
        }

        private static void ProcessDebugEvent(DEBUG_EVENT evt)
        {
            if (evt.dwDebugEventCode != DebugEventType.NONE)
            {
                Events.Add(evt);
            }

            var log = EventString(evt);

            if (!string.IsNullOrEmpty(log))
            {
                Timeline.Add(log);
                DebuggerLog(log);
            }

            Prompt();
        }

        private static string ProcessExceptionDebugEvent(DEBUG_EVENT evt)
        {
            return $"[EXCEPTION DEBUG] ExceptionCode: {evt.Exception.ExceptionRecord.ExceptionCode}";
            // TODO throw new NotImplementedException();
        }

        private static string ProcessUnloadDllDebugEvent(DEBUG_EVENT evt)
        {
            return $"[DLL UNLOADED] {LoadedDlls[evt.UnloadDll.lpBaseOfDll]}";
        }

        private static string ProcessRipEvent(DEBUG_EVENT evt)
        {
            return $"[RIP] Err: {evt.RipInfo.dwError} | Type: {evt.RipInfo.dwType}";
        }

        private static string ProcessExitThreadEvent(DEBUG_EVENT evt)
        {
            return $"[THREAD EXIT] ExitCode: {evt.ExitThread.dwExitCode.ToHex()}";
        }

        private static string ProcessExitProcessEvent(DEBUG_EVENT evt)
        {
            return $"[PROCESS EXIT] ExitCode: {evt.ExitProcess.dwExitCode.ToHex()}";
        }

        private static string ProcessCreateProcessEvent(DEBUG_EVENT evt)
        {
            // // Get the file size.
            uint dwFileSizeHi = 0;
            uint dwFileSizeLo = NativeMethods.GetFileSize(evt.LoadDll.hFile, out dwFileSizeHi);

            StringBuilder sb = new StringBuilder(2048);

            NativeMethods.GetFinalPathNameByHandle(evt.CreateProcessInfo.hFile, sb, 2048, FinalPathFlags.FILE_NAME_NORMALIZED);

            return $"[PROCESS CREATED] {sb.ToString()}";
        }

        private static string ProcessCreateThreadEvent(DEBUG_EVENT evt)
        {
            return $"[THREAD CREATED] {evt.CreateThread.hThread.ToHex()}";
        }

        private static string ProcessLoadDLLEvent(DEBUG_EVENT evt)
        {
            // // Get the file size.
            uint dwFileSizeHi = 0;
            uint dwFileSizeLo = NativeMethods.GetFileSize(evt.LoadDll.hFile, out dwFileSizeHi);

            StringBuilder sb = new StringBuilder(2048);

            NativeMethods.GetFinalPathNameByHandle(evt.LoadDll.hFile, sb, 2048, FinalPathFlags.FILE_NAME_NORMALIZED);

            string dllName = sb.ToString();
            LoadedDlls[evt.LoadDll.lpBaseOfDll] = dllName;

            return $"[DLL LOAD] {dllName}";

        }

        private static string ProcessOutputDebugStringEvent(DEBUG_EVENT evt)
        {
            //var data = evt.DebugString.lpDebugStringData;
            byte[] buffer = new byte[evt.DebugString.nDebugStringLength - 1];
            IntPtr bytesReadPtr = IntPtr.Zero;

            NativeMethods.ReadProcessMemory(
                debuggee.Handle,
                evt.DebugString.lpDebugStringData,
                buffer,
                evt.DebugString.nDebugStringLength - 1,
                out bytesReadPtr);

            var err = Marshal.GetLastWin32Error();
            var text = Encoding.UTF8.GetString(buffer).TrimEnd('\r', '\n');

            return text;
        }

        private static Process StartDebuggee(CreateProcessFlags flags)
        {
            PROCESS_INFORMATION pInfo = NativeHelpers.CreateProcess(
                applicationName: "Debuggee.exe",
                commandLine: null,
                flags: flags
    );

            var process = Process.GetProcessById(pInfo.dwProcessId);
            Console.WriteLine($@"{process.ProcessName} started for debugging: PID: {pInfo.dwProcessId}");

            return process;
        }

        static void CommandLoop()
        {
            var command = Console.ReadLine().Trim();

            switch (command)
            {
                case "!res":
                    Stop();
                    ClearEvents();
                    StartDebuggee(CreateProcessFlags.DEBUG_ONLY_THIS_PROCESS);
                    break;
                case "!a":
                    Prompt("? Enter PID of the debuggee: ");
                    var pid = int.Parse(Console.ReadLine().Trim());

                    var result = NativeMethods.DebugActiveProcess(pid);
                    var err = Marshal.GetLastWin32Error();

                    if (err == decimal.Zero)
                    {
                        DebuggerLog($"Debugger is attached to PID: {pid}");
                        Console.WriteLine();
                    }
                    else
                    {
                        DebuggerLog($"error code: {err}.");
                        Console.WriteLine();
                    }


                    break;
                case "!dlls":
                    LoadedDlls.ToList().ForEach(x =>
                    {
                        Console.WriteLine($"- {x.Key.ToHex()} {x.Value}");
                    });

                    break;
                case "!s":
                    Stop();

                    Console.WriteLine();

                    break;

                case "!events":
                    for (int i = 0; i < Events.Count; i++)
                    {
                        Console.WriteLine($"#{i} {Events[i].dwDebugEventCode}");
                    }

                    break;
                case "!timeline":
                    for (int i = 0; i < Timeline.Count; i++)
                    {
                        Console.WriteLine($"#{i} {Timeline[i]}");
                    }

                    break;
                case "!h":
                    Console.WriteLine("help TODO");
                    break;
                case "!n":
                default:
                    ERROR = NativeMethods.WaitForDebugEvent(out EVENT, WAITFOR_MS);
                    OK = ContinueDebugEvent(EVENT.dwProcessId, EVENT.dwThreadId, ContinueStatus.DBG_CONTINUE);
                    ERROR_CODE = Marshal.GetLastWin32Error();
                    ProcessDebugEvent(EVENT);
                    Console.WriteLine();
                    break;
            }


            Prompt();
            CommandLoop();
        }

        private static void ClearEvents()
        {
            Events.Clear();
            Timeline.Clear();
            LoadedDlls.Clear();
        }

        private static void Stop()
        {
            if (!debuggee.HasExited)
            {
                debuggee.Kill();
            }
        }

        private static void Prompt()
        {
            Console.Write(">> ");
        }

        private static void Prompt(string prefix)
        {
            Console.Write($">> {prefix}");
        }
    }
}


public static class Exts
{
    public static string ToHex(this IntPtr value) => String.Format("0x{0:X}", value);
    public static string ToHex(this int value) => String.Format("0x{0:X}", value);
    public static string ToHex(this uint value) => String.Format("0x{0:X}", value);
}