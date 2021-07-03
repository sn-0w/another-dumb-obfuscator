using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmao
{
    class renamerjunk
    {
        private static Random RDG = new Random();

        public static String RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789诶比西迪伊艾弗吉艾尺艾杰开艾勒艾马艾娜哦屁吉吾艾儿艾";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[RDG.Next(s.Length)]).ToArray());
        }

      
            public static void Renamer(ModuleDef moduleDef)
        {
            moduleDef.Name = "FloppaᅠGamingᅠ<OBFUSCATOR>";
            moduleDef.GlobalType.Name = "FloppaᅠGamingᅠ<OBFUSCATOR>";
            moduleDef.GlobalType.Namespace = "FloppaᅠGamingᅠ<OBFUSCATOR>";
            moduleDef.EntryPoint.Name = "FloppaᅠGamingᅠ<OBFUSCATOR>";
            foreach (var type in moduleDef.Types)
            {

                //type.Namespace = "";
                if (type.IsClass)
                {
                    type.Name = "FloppaᅠGamingᅠ<OBFUSCATOR>";
                }
            }
            if (true)
            {
                Random rnd = new Random();
                InterfaceImpl Interface = new InterfaceImplUser(moduleDef.GlobalType);
                for (int i = 1500; i < 1600; i++)
                {
                    //TypeDef typedef = new TypeDefUser(RandomString(12) + $"{i.ToString()}", moduleDef.CorLibTypes.GetTypeRef("System", "Attribute"));
                    TypeDef typedef = new TypeDefUser(String.Concat(Enumerable.Repeat("ᅠ", i - 1499)), moduleDef.CorLibTypes.GetTypeRef("System", "Attribute"));
                    InterfaceImpl interface1 = new InterfaceImplUser(typedef);
                    moduleDef.Types.Add(typedef);
                    typedef.Interfaces.Add(interface1);
                    typedef.Interfaces.Add(Interface);
                }

                foreach (var md in moduleDef.Types)
                {
                    if (md.IsGlobalModuleType) continue;
                    for (int i = 0; i < RDG.Next(20, 30); i++)
                    {
                        CorLibTypeSig corLibTypeSig = md.Module.CorLibTypes.String;
                        MethodDef methodDef = new MethodDefUser("ᅠ", MethodSig.CreateStatic(corLibTypeSig), MethodImplAttributes.IL | MethodImplAttributes.Managed, MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig)
                        {
                            Body = new CilBody()
                        };
                        md.Methods.Add(methodDef);
                        for (int t = 0; t < RDG.Next(100, 330); t++)
                        {
                            methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, "Floppa Gaming <OBFUSCATOR> (https://discord.gg/HQKszmcUwJ) Created By Snow."));
                        }
                        methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, "Enjoy Cracking it."));
                        methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
                    }
                }
                MethodDefUser methodDefUser = new MethodDefUser("data_sender_callpoint", MethodSig.CreateStatic(moduleDef.CorLibTypes.String, moduleDef.CorLibTypes.String), MethodImplAttributes.IL | MethodImplAttributes.Managed, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.ReuseSlot)
                {
                    Body = new CilBody()
                };
                for (int t = 0; t < 100; t++)
                {
                    methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, "Sending Data... " + t * 0.1 + "%"));
                }
                methodDefUser.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, "Data sent!"));
                methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
                moduleDef.GlobalType.Methods.Add(methodDefUser);

                for (int t = 0; t < 100; t++)
                {
                    MethodDefUser thething = new MethodDefUser(NamingList.Method1[RDG.Next(0, NamingList.Method1.Count)] + RDG.Next(0, 9999).ToString(), MethodSig.CreateStatic(moduleDef.CorLibTypes.String, moduleDef.CorLibTypes.String), MethodImplAttributes.IL | MethodImplAttributes.Managed, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.ReuseSlot)
                    {
                        Body = new CilBody()
                    };
                    thething.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, String.Concat(Enumerable.Repeat("Floppa Gaming" + "ᅠ", 50000))));
                    thething.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, "Floppa Gaming <OBFUSCATOR> (https://discord.gg/HQKszmcUwJ) Created By Snow."));
                    thething.Body.Instructions.Add(new Instruction(OpCodes.Ret));
                    moduleDef.GlobalType.Methods.Add(thething);
                }
            }
        }
    }
}
