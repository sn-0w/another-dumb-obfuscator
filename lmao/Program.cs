using dnlib.DotNet;
using dnlib.DotNet.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lmao
{
    class Program
    {
        static void Main(string[] args)
		{ 
			string text = args[0];
			string path2 = text.Replace("\"", "");
			byte[] filebytes = File.ReadAllBytes(path2);
			AssemblyDef assembly = AssemblyDef.Load(filebytes);
			string origninalname = assembly.Name;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Obfuscation Started!");
			var modules = ModuleDefMD.Load(filebytes);

			stringprotect.StringProtect(modules);
			proxystring.prxstr(modules);
			proxymethod.prxmeth(modules);
			cflow.cflow.cflowgo(modules);
			cflow.jumpcflw.yeet(modules);
			renamerjunk.Renamer(modules);

			modules.Write($"{origninalname}-protected.exe",new ModuleWriterOptions(modules){ PEHeadersOptions = { NumberOfRvaAndSizes = 13 }, Logger = DummyLogger.NoThrowInstance });

			//modules.Write($"{assembly.Name}-protected.exe");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Obfuscation Done!");
			Console.Read();

		}
    }

	
}
