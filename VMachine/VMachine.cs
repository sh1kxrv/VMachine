using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;
using VMachine.Handlers;
using VMachine.Handlers.Arithmetic;
using VMachine.Handlers.Const;
using VMachine.Handlers.Misc;

namespace VMachine
{
    public class VMachine
    {
        /// <summary>
        /// Stack for data storage (operands)
        /// </summary>
        public VMStack VStack;
        private Dictionary<OpCode, AHandler> RegisteredOpCodes;
        public VMachine()
        {
            VStack = new VMStack();
            RegisteredOpCodes = new Dictionary<OpCode, AHandler>();
            Setup();
        }
        private void Setup()
        {
            #region Arithmetic
            RegisteredOpCodes.Add(OpCodes.Add, new Add());
            RegisteredOpCodes.Add(OpCodes.Mul, new Mul());
            RegisteredOpCodes.Add(OpCodes.Sub, new Sub());
            RegisteredOpCodes.Add(OpCodes.Xor, new Xor());
            RegisteredOpCodes.Add(OpCodes.Not, new Not());
            RegisteredOpCodes.Add(OpCodes.Or, new Or());
            RegisteredOpCodes.Add(OpCodes.And, new And());
            #endregion
            #region LDC_I4
            RegisteredOpCodes.Add(OpCodes.Ldc_I4, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_0, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_1, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_2, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_3, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_4, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_5, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_6, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_7, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_8, new LdcI4());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_M1, new LdcI4_M1());
            RegisteredOpCodes.Add(OpCodes.Ldc_I4_S, new LdcI4_S());
            RegisteredOpCodes.Add(OpCodes.Ldc_I8, new LdcI8());
            RegisteredOpCodes.Add(OpCodes.Ldc_R4, new LdcR4());
            RegisteredOpCodes.Add(OpCodes.Ldc_R8, new LdcR8());
            #endregion
            #region Misc
            RegisteredOpCodes.Add(OpCodes.Ret, new Ret());
            #endregion
        }
        public object Execute(List<Instruction> Instructions)
        {
            try
            {
                for (int i = 0; i < Instructions.Count; i++)
                {
                    Instruction instruction = Instructions[i];
                    AHandler handler = RegisteredOpCodes[instruction.OpCode];
                    handler.ExecuteOpCode(VStack, instruction);
                }
                return VStack.VM.Count != 0 ? VStack.VM.Pop() : null;
            }
            finally
            {
                VStack.VM.Clear();
                GC.Collect();
            }
        }
    }
}
