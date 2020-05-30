using CommandLine;
using System;
using System.Diagnostics;

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
                    Process.Start(o.Process);
                });
        }
    }
}
