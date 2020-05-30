using CommandLine;
using System.IO;

namespace DbgNet
{
    public class Options
    {
        [Option('l', "load-dll", HelpText = "Subscribe to Load DLL events")] public bool LoadDLL { get; set; }
        [Option('u', "unload-dll", HelpText = "Subscribe to Unload DLL events")] public bool UnloadDLL { get; set; }
        [Option('p', "process-create", HelpText = "Subscribe to Create Process events")] public bool CreateProcess { get; set; }
        [Option('x', "process-exit", HelpText = "Subscribe to Exit Process events")] public bool ExitProcess { get; set; }

        [Option('t', "thread-create", HelpText = "Subscribe to Create Thread events")] public bool CreateThread { get; set; }
        [Option('e', "thread-exit", HelpText = "Subscribe to Exit Thread Events")] public bool ExitThread { get; set; }
        [Option('c', "exception", HelpText = "Subscribe to Exception Events")] public bool Exception { get; set; }


        [Value(0, MetaName = "process", HelpText = "Process to be Debugged")]
        public string Process { get; set; }
    }
}