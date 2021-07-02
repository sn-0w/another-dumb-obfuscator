using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmao
{
    class stringprotect
    {
        public static void StringProtect(ModuleDef moduleDef)
        {
            foreach (TypeDef type in moduleDef.Types)
            {
                foreach (MethodDef method in type.Methods)
                {
                    if (method.Body == null) continue;
                    for (int i = 0; i < method.Body.Instructions.Count(); i++)
                    {
                        if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                        {

                            String oldString = method.Body.Instructions[i].Operand.ToString();
                            if (!oldString.StartsWith("Floppa"))
                            {
                                String newString = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(oldString));
                                method.Body.Instructions[i].OpCode = OpCodes.Nop;
                                method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, moduleDef.Import(typeof(Encoding).GetMethod("get_UTF8", new Type[] { }))));
                                method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, newString));
                                method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, moduleDef.Import(typeof(Convert).GetMethod("FromBase64String", new Type[] { typeof(string) }))));
                                method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, moduleDef.Import(typeof(Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) }))));
                                i += 4;
                                CorLibTypeSig corLibTypeSig = moduleDef.CorLibTypes.String;
                                MethodDef methodDef = new MethodDefUser("a_string", MethodSig.CreateStatic(corLibTypeSig), MethodImplAttributes.IL | MethodImplAttributes.Managed, MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig)
                                {
                                    Body = new CilBody()
                                };
                                methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, "Enjoy Cracking it."));
                                methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
                            }
                        }
                    }
                }
            }
        }
    }
}
