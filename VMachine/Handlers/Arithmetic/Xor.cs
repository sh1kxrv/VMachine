using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMachine.Handlers.Arithmetic
{
    public class Xor : AHandler
    {
        public override void ExecuteOpCode(VMStack stack, Instruction instruction)
        {
            var x = stack.VM.Pop();
            var y = stack.VM.Pop();
            stack.VM.Push(y ^ x);
        }
    }
}
