using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMachine.Handlers.Const
{
    public class LdcI4_S : AHandler
    {
        public override void ExecuteOpCode(VMStack stack, Instruction instruction)
        {
            stack.VM.Push((sbyte)instruction.GetLdcI4Value());
        }
    }
}
