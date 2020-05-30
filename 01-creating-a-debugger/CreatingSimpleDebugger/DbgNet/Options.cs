using CommandLine;
using System.IO;

namespace DbgNet
{
    class Options
    {
        [Option('l', "list-dlls", HelpText = "List DLLs")]
        public bool ListDlls { get; set; }

        [Value(0, MetaName = "process", HelpText = "Process to be Debugged")]
        public string Process { get; set; }
    }
}