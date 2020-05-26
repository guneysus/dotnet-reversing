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
    internal static class Program
    {
        static Process debuggee;
        static List<DEBUG_EVENT> events = new List<DEBUG_EVENT>();

        static void Main(string[] args)
        {
            debuggee = StartDebuggee(CreateProcessFlags.DEBUG_ONLY_THIS_PROCESS);

            while (true)
            {
                CommandLoop();
            }
        }

        private static void ProcessDebugEvent(DEBUG_EVENT evt)
        {
            events.Add(evt);
            Console.WriteLine($"Event: {evt.dwDebugEventCode}");

            switch (evt.dwDebugEventCode)
            {
                case DebugEventType.RIP_EVENT:
                    break;
                case DebugEventType.OUTPUT_DEBUG_STRING_EVENT:
                    //var data = evt.DebugString.lpDebugStringData;
                    byte[] buffer = new byte[1024] ;
                    IntPtr bytesReadPtr = IntPtr.Zero;

                        NativeMethods.ReadProcessMemory(
                    debuggee.Handle,
                    evt.DebugString.lpDebugStringData,
                    buffer,
                    evt.DebugString.nDebugStringLength,
                    out bytesReadPtr);

                    var err = Marshal.GetLastWin32Error();
                    var text = Encoding.UTF8.GetString(buffer);

                    break;
                case DebugEventType.UNLOAD_DLL_DEBUG_EVENT:
                    break;
                case DebugEventType.LOAD_DLL_DEBUG_EVENT:
                    break;
                case DebugEventType.EXIT_PROCESS_DEBUG_EVENT:
                    break;
                case DebugEventType.EXIT_THREAD_DEBUG_EVENT:
                    break;
                case DebugEventType.CREATE_PROCESS_DEBUG_EVENT:
                    // get file name from handle
                    //var handle = debugEvent.CreateProcessInfo.hFile;
                    //var result = Marshal.PtrToStringAuto(handle);
                    //uint lpFileSizeHigh;
                    //var lpFileSizeLow = NativeMethods.GetFileSize(debugEvent.CreateProcessInfo.hFile, out lpFileSizeHigh);
                    break;
                case DebugEventType.CREATE_THREAD_DEBUG_EVENT:
                    break;
                case DebugEventType.EXCEPTION_DEBUG_EVENT:
                    break;
                default:
                    break;
            }
        }

        private static Process StartDebuggee(CreateProcessFlags flags)
        {
            PROCESS_INFORMATION pInfo = NativeHelpers.CreateProcess(
                applicationName: "Debuggee.exe",
                commandLine: null,
                flags: flags
    );

            var process = Process.GetProcessById(pInfo.dwProcessId);
            Console.WriteLine($@"
ERROR           {Marshal.GetLastWin32Error()}
PROCESS         {process.ProcessName}
PID             {pInfo.dwProcessId}
THREAD ID       {pInfo.dwThreadId}
Process Handle  {pInfo.hProcess}
Thread Handle   {pInfo.hThread}
");

            return process;
        }


        static void CommandLoop()
        {
            Console.Write(">> ");
            var command = Console.ReadLine().Trim();

            switch (command)
            {
                case "attach":
                    Console.WriteLine("Enter PID of the debuggee:");
                    var pid = int.Parse(Console.ReadLine().Trim());

                    var result = NativeMethods.DebugActiveProcess(pid);
                    var err = Marshal.GetLastWin32Error();
                    if (err == decimal.Zero)
                    {
                        Console.Write($"Debugger is attached to PID: {pid}");
                    }
                    else
                    {
                        Console.Write($"error code: {err}.");
                    }
                    break;

                case "stop":
                case "!s":
                    break;
                case "debug":
                case "d":
                    DEBUG_EVENT debugEvent;
                    uint waitForMs = (uint)TimeSpan.FromMinutes(120).TotalMilliseconds;
                    bool error = true;

                    do
                    {
                        error = NativeMethods.WaitForDebugEvent(out debugEvent, waitForMs);
                        ProcessDebugEvent(debugEvent);
                        var ok = ContinueDebugEvent(debugEvent.dwProcessId, debugEvent.dwThreadId, ContinueStatus.DBG_CONTINUE);
                        var errCode = Marshal.GetLastWin32Error();
                    } while (error);

                    break;
                default:
                    break;
            }

            CommandLoop();
        }

    }
}
