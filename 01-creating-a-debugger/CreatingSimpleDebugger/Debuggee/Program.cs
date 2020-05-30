using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;

namespace Debuggee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myPid = Process.GetCurrentProcess().Id;
            Console.WriteLine("MYPID: " + myPid);

            //return;

            var ticker = new System.Timers.Timer(1000);

            ticker.Elapsed += Ticker_Elapsed;
            ticker.Start();

            while (true)
            {
                Console.ReadLine();
            }
            
        }

        private static void Ticker_Elapsed(object sender, ElapsedEventArgs e)
        {
            HeartBeat();
        }

        private static void HeartBeat()
        {
            var ts = DateTime.Now.ToString();
            Trace.WriteLine("[TRACE] " + ts); 
            //Debug.WriteLine($"[DEBUG] {ts}"); 
        }
    }
}
