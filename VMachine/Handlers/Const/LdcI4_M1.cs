using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMachine.Handlers.Const
{
    public class LdcI4_M1 : AHandler
    {
        public override void ExecuteOpCode(VMStack stack, Instruction instruction)
        {
            stack.VM.Push(-1);
        }
    }
}
