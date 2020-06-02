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
    public delegate void LoadDLL(IntPtr address);
    public delegate void UnloadDLL(IntPtr address);

    public delegate void CreateProcess(string name);
    public delegate void ExitProcess(string name);

    public delegate void CreateThread(string msg);
    public delegate void ExitThread(string msg);

    public delegate void Exception(string msg);

    class Program
    {
        static Debugger debugger;

        static void Main(string[] args)
        {

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opt =>
                {
                    //debugger.Pause();
                    debugger = new Debugger(opt);
                    debugger.Start();
                });

            do
            {
                Console.ReadLine();
            } while (true);

            //do
            //{
            //    var command = Console.ReadLine();
            //    switch (command)
            //    {
            //        case "!detach":
            //            var result = NativeMethods.DebugActiveProcessStop(debugger.ProcessId);
            //            var code = Marshal.GetLastWin32Error();
            //            Console.WriteLine($"{result} code:{code}");
            //            break;
            //        default:
            //            break;
            //    }
            //} while (true);
        }

        private static void ReplLoop()
        {

        }
    }

}

