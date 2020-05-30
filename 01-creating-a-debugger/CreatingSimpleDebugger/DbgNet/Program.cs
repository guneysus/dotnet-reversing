using CommandLine;
using DbgNet.Core;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace DbgNet
{
    class Program
    {
        static Options Options;

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    PROCESS_INFORMATION pInfo = NativeHelpers.CreateProcess(
                        applicationName: null,
                        commandLine: o.Process,
                        flags: CreateProcessFlags.DEBUG_PROCESS
                    );

                    Process debuggee = Process.GetProcessById(pInfo.dwProcessId);
                    Console.WriteLine($@"{debuggee.ProcessName} started for debugging: PID: {pInfo.dwProcessId}");


                    const int DLLPATH_BUFFER_SIZE = 2048;
                    DEBUG_EVENT EVENT;
                    uint WAITFOR_MS = (uint)TimeSpan.FromMilliseconds(5).TotalMilliseconds;
                    bool ERROR = true;
                    int ERROR_CODE = -1;
                    bool OK = false;
                    ContinueStatus DBG_CONTINUE_NEXT_STATUS = ContinueStatus.DBG_CONTINUE;
                    StringBuilder sb = new StringBuilder(DLLPATH_BUFFER_SIZE);

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
                                break;
                            case DebugEventType.LOAD_DLL_DEBUG_EVENT:

                                NativeMethods.GetFinalPathNameByHandle(EVENT.LoadDll.hFile, sb, DLLPATH_BUFFER_SIZE, FinalPathFlags.VOLUME_NAME_NONE);

                                string dllName = sb.ToString();
                                Console.WriteLine(dllName);

                                break;
                            case DebugEventType.EXIT_PROCESS_DEBUG_EVENT:
                                break;
                            case DebugEventType.EXIT_THREAD_DEBUG_EVENT:
                                break;
                            case DebugEventType.CREATE_PROCESS_DEBUG_EVENT:

                                NativeMethods.GetFinalPathNameByHandle(EVENT.CreateProcessInfo.hFile, sb, DLLPATH_BUFFER_SIZE, FinalPathFlags.FILE_NAME_NORMALIZED);

                                break;
                            case DebugEventType.CREATE_THREAD_DEBUG_EVENT:
                                break;
                            case DebugEventType.EXCEPTION_DEBUG_EVENT:
                                DBG_CONTINUE_NEXT_STATUS = ContinueStatus.DBG_EXCEPTION_NOT_HANDLED;
                                break;
                            default:
                                break;

                        }

                        Console.ReadLine();


                        OK = NativeMethods.ContinueDebugEvent(EVENT.dwProcessId, EVENT.dwThreadId, DBG_CONTINUE_NEXT_STATUS);
                        ERROR_CODE = Marshal.GetLastWin32Error();
                    } while (true);
                });
        }
    }
}
