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
        static void Main(string[] args)
        {

            Debugger debugger;
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opt =>
                {
                    debugger = new Debugger(opt);
                    debugger.Run();
                });

            do
            {
                Console.ReadLine();
            } while (true);
        }
    }

}

