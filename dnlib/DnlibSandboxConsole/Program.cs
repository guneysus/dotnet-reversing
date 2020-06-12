using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace DnlibSandboxConsole
{
    class Program
    {
        private const string MYEXE = @"samples\MyForm.exe";

        static void Main(string[] args)
        {


            #region Read a .NET module from a file:
            // Create a default assembly resolver and type resolver and pass it to Load().
            // If it's a .NET Core assembly, you'll need to disable GAC loading and add
            // .NET Core reference assembly search paths.
            ModuleContext modCtx = ModuleDef.CreateModuleContext();
            ModuleDefMD module = ModuleDefMD.Load(MYEXE, modCtx);
            #endregion


            //#region Write PDB files
            //// Create a default assembly resolver and type resolver
            ////ModuleContext modCtx = ModuleDef.CreateModuleContext();
            //var mod = ModuleDefMD.Load(MYEXE, modCtx);
            //// ...
            //var wopts = new dnlib.DotNet.Writer.ModuleWriterOptions(mod);
            //wopts.WritePdb = true;
            //wopts.PdbFileName = @"out.pdb";	// Set other file name
            //mod.Write(@"out.dll", wopts);
            //#endregion
        }
    }
}
