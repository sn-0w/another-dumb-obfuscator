using dnlib.DotNet;
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
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Obfuscation Started!");
			var modules = ModuleDefMD.Load(filebytes);
			renamer.Renamer(modules);
			stringprotect.StringProtect(modules);
			proxystring.prxstr(modules);
			modules.Write($"{assembly.Name}-protected.exe");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Obfuscation Done!");
			Console.Read();

		}
    }

	
}
