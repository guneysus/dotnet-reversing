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
            debuggee = StartDebuggee(CreateProcessFlags.DEBUG_ONLY_THIS_PROCESS | CreateProcessFlags.CREATE_NEW_CONSOLE);

            while (true)
            {
                CommandLoop();
            }
        }

        private static void ProcessDebugEvent(DEBUG_EVENT evt)
        {
            events.Add(evt);
            //Console.WriteLine($"Event: {evt.dwDebugEventCode}");

            switch (evt.dwDebugEventCode)
            {
                case DebugEventType.RIP_EVENT:
                    break;
                case DebugEventType.OUTPUT_DEBUG_STRING_EVENT:
                    ProcessOutputDebugStringEvent(evt);
                    break;
                case DebugEventType.UNLOAD_DLL_DEBUG_EVENT:
                    break;
                case DebugEventType.LOAD_DLL_DEBUG_EVENT:
                    ProcessLoadDLLEvent(evt);
                    break;
                case DebugEventType.EXIT_PROCESS_DEBUG_EVENT:
                    ProcessExitProcessEvent(evt);
                    break;
                case DebugEventType.EXIT_THREAD_DEBUG_EVENT:
                    ProcessExitThreadEvent(evt);
                    break;
                case DebugEventType.CREATE_PROCESS_DEBUG_EVENT:
                    ProcessCreateProcessEvent(evt);
                    break;
                case DebugEventType.CREATE_THREAD_DEBUG_EVENT:
                    ProcessCreateThreadEvent(evt);
                    break;
                case DebugEventType.EXCEPTION_DEBUG_EVENT:
                    break;
                default:
                    break;
            }
        }

        private static void ProcessExitThreadEvent(DEBUG_EVENT evt)
        {
            Console.WriteLine($"[THREAD EXIT] ExitCode: {evt.ExitThread.dwExitCode.ToHex()}");
        }

        private static void ProcessExitProcessEvent(DEBUG_EVENT evt)
        {
            Console.WriteLine($"[PROCESS EXIT] ExitCode: {evt.ExitProcess.dwExitCode.ToHex()}");
        }

        private static void ProcessCreateProcessEvent(DEBUG_EVENT evt)
        {
            Console.WriteLine($"[PROCESS CREATED] hProcess: {evt.CreateProcessInfo.hProcess.ToHex()} hFile:{evt.CreateProcessInfo.hFile}");
        }

        private static void ProcessCreateThreadEvent(DEBUG_EVENT evt)
        {
            var t = evt.CreateThread.lpStartAddress.Method;
            
            Console.WriteLine($"[THREAD CREATED] " +
                $"h:{evt.CreateThread.hThread.ToHex()} " +
                $"lpLocalBase:{evt.CreateThread.lpThreadLocalBase.ToHex()}");
        }

        private static void ProcessLoadDLLEvent(DEBUG_EVENT evt)
        {
            // // Get the file size.
            uint dwFileSizeHi = 0;
            uint dwFileSizeLo = NativeMethods.GetFileSize(evt.LoadDll.hFile, out dwFileSizeHi);
            var lpFilename = new StringBuilder(250);

            if (dwFileSizeLo == 0 & dwFileSizeLo == 0)
            {
                throw new Exception();
            }

            // Create a file mapping object.
            IntPtr hFileMap = IntPtr.Zero;
            string lpName;
            char[] pszFilename = new char[1024];

            hFileMap = NativeMethods.CreateFileMapping(
                evt.LoadDll.hFile,
                IntPtr.Zero,
                FileMapProtection.PageReadonly,
                dwFileSizeHi,
                dwFileSizeLo, out lpName);

            var err = Marshal.GetLastWin32Error();

            if (hFileMap != IntPtr.Zero & err == decimal.Zero)
            {
                // Create a file mapping to get the file name.
                IntPtr pMem = IntPtr.Zero;
                pMem = NativeMethods.MapViewOfFile(hFileMap, FileMapAccessType.Read, 0, 0, 250);
                if (Marshal.GetLastWin32Error() == decimal.Zero & pMem !=  IntPtr.Zero)
                {
                }
            }
        }

        private static void ProcessOutputDebugStringEvent(DEBUG_EVENT evt)
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
            Trace.WriteLine(text);
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


public static class Exts {
    public static string ToHex(this IntPtr value) => String.Format("0x{0:X}", value);
    public static string ToHex(this int value) => String.Format("0x{0:X}", value);
    public static string ToHex(this uint value) => String.Format("0x{0:X}", value);
}