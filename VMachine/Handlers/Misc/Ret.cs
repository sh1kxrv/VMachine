using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMachine.Handlers.Misc
{
    public class Ret : AHandler
    {
        public override void ExecuteOpCode(VMStack stack, Instruction instruction)
        {
            if (stack.VM.Count == 0)
                stack.VM.Push(null);
            else
                stack.VM.Push(stack.VM.Pop());
        }
    }
}
