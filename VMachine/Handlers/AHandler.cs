using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMachine.Handlers
{
    public abstract class AHandler
    {
        public abstract void ExecuteOpCode(VMStack stack, Instruction instruction);
    }
}
