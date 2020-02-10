using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet.Emit;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Instruction emulator | v1.0 | VMachine";
            Console.WriteLine($"Execution...");
            VMachine.VMachine VM = new VMachine.VMachine();
            List<Instruction> Add = new List<Instruction>()
            {
                Instruction.Create(OpCodes.Ldc_R8, 22.4),
                Instruction.Create(OpCodes.Ldc_R8, 50.6),
                Instruction.Create(OpCodes.Add),
                Instruction.Create(OpCodes.Ret)
            };
            List<Instruction> Sub = new List<Instruction>()
            {
                Instruction.Create(OpCodes.Ldc_I4, 22),
                Instruction.Create(OpCodes.Ldc_I4, 22),
                Instruction.Create(OpCodes.Sub),
                Instruction.Create(OpCodes.Ret)
            };
            List<Instruction> SubAdd = new List<Instruction>()
            {
                Instruction.CreateLdcI4(44),
                Instruction.CreateLdcI4(52),
                Instruction.Create(OpCodes.Sub),
                Instruction.CreateLdcI4(22),
                Instruction.CreateLdcI4(44),
                Instruction.Create(OpCodes.Sub),
                Instruction.Create(OpCodes.Add)
            };
            Console.WriteLine($"50.6 + 22.4: {VM.Execute(Add)}");
            Console.WriteLine($"22 - 22: {VM.Execute(Sub)}");
            Console.WriteLine($"44 - 52 + 22 - 44: {VM.Execute(SubAdd)}");
            Console.ReadLine();
        }
    }
}
