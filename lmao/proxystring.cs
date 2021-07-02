using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmao
{
    class proxystring
    {
        public static Random rand = new Random();

        public static void prxstr(ModuleDef module)
        {
            foreach (var type in module.GetTypes())
            {
                if (type.IsGlobalModuleType) continue;
                foreach (var method in type.Methods)
                {
                    if (!method.HasBody) continue;
                    var instr = method.Body.Instructions;
                    foreach (var t in instr)
                    {
                        if (t.OpCode != OpCodes.Ldstr) continue;
                        if (t.Operand.ToString().Contains("FloppaᅠGamingᅠ<OBFUSCATOR>")) continue;
                        if (t.Operand.ToString().Contains("https://discord.gg/HQKszmcUwJ")) continue;
                        Console.WriteLine(t.Operand.ToString());
                        var methImplFlags = MethodImplAttributes.IL | MethodImplAttributes.Managed;
                        var methFlags = MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig | MethodAttributes.ReuseSlot;
                        var meth1 = new MethodDefUser("FloppaᅠGamingᅠ<OBFUSCATOR>ᅠ"+rand.Next(0,1000000000),
                            MethodSig.CreateStatic(module.CorLibTypes.String),
                            methImplFlags, methFlags);
                        module.GlobalType.Methods.Add(meth1);
                        meth1.Body = new CilBody();
                        meth1.Body.Variables.Add(new Local(module.CorLibTypes.String));
                        meth1.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, t.Operand.ToString()));
                        meth1.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));

                        t.OpCode = OpCodes.Call;
                        t.Operand = meth1;
                    }
                }
            }
        }
    }
}

