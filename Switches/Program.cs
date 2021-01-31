using System;
using System.Linq;
using System.Reflection.Emit;

namespace Switches
{
    class Program
    {
        static void Main(string[] args)
        {
            var add = Math.GetResult(20, 10, 0);
            var mul = Math.GetResult(20, 10, 1);
            var div = Math.GetResult(20, 10, 2);
            var sub = Math.GetResult(20, 10, 3);
            var zero = Math.GetResult(20, 10, -1);

            Console.WriteLine($"Add : {add}");
            Console.WriteLine($"Mul : {mul}");
            Console.WriteLine($"Div : {div}");
            Console.WriteLine($"Sub : {sub}");
            Console.WriteLine($"Zero : {zero}");

            Console.WriteLine();


            #region Dynamic Method
            Console.WriteLine("----- Using Dynamic Method");
            var switchMethod = new DynamicMethod("MyMethod",
                                                                                                typeof(int),
                                                                                                 new[] { typeof(int), typeof(int),typeof(int)},
                                                                                                 typeof(Program).Module);
            var il = switchMethod.GetILGenerator();

            // Jump table... array of labels
            var jumpTable = new[] { il.DefineLabel(),       // Addition
                                                            il.DefineLabel(),       // Multiplication
                                                            il.DefineLabel(),       // Division
                                                            il.DefineLabel(),        // Subtractions
                                                            il.DefineLabel()        // Default case
                                                            };

            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Switch, jumpTable);
            il.Emit(OpCodes.Br, jumpTable.Last());

            il.MarkLabel(jumpTable[0]);     // Addition
            il.Emit(OpCodes.Ldarg_0);           // Place 1st parameter value on evaluation stack
            il.Emit(OpCodes.Ldarg_1);           // Place 2nd parameter value on evaluation stack
            il.Emit(OpCodes.Add);                   // Pop parameters and place result on evaluation stack
            il.Emit(OpCodes.Ret);

            il.MarkLabel(jumpTable[1]);     // Multiplication
            il.Emit(OpCodes.Ldarg_0);           // Place 1st parameter value on evaluation stack
            il.Emit(OpCodes.Ldarg_1);           // Place 2nd parameter value on evaluation stack
            il.Emit(OpCodes.Mul) ;                   // Pop parameters and place result on evaluation stack
            il.Emit(OpCodes.Ret);

            il.MarkLabel(jumpTable[2]);     // Division
            il.Emit(OpCodes.Ldarg_0);           // Place 1st parameter value on evaluation stack
            il.Emit(OpCodes.Ldarg_1);           // Place 2nd parameter value on evaluation stack
            il.Emit(OpCodes.Div);                   // Pop parameters and place result on evaluation stack
            il.Emit(OpCodes.Ret);

            il.MarkLabel(jumpTable[3]);     // Subtraction
            il.Emit(OpCodes.Ldarg_0);           // Place 1st parameter value on evaluation stack
            il.Emit(OpCodes.Ldarg_1);           // Place 2nd parameter value on evaluation stack
            il.Emit(OpCodes.Sub);                   // Pop parameters and place result on evaluation stack
            il.Emit(OpCodes.Ret);

            il.MarkLabel(jumpTable[4]);     // Default
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Ret);

            // Create the delegate
            var method = (Func<int, int, int, int>) switchMethod.CreateDelegate(typeof(Func<int, int, int, int>));

            var addDyn = method(20, 10, 0);
            var mulDyn = method(20, 10, 1);
            var divDyn = method(20, 10, 2);
            var subDyn = method(20, 10, 3);
            var zeroDyn = method(20, 10, -1);

            Console.WriteLine($"Add : {addDyn}");
            Console.WriteLine($"Mul : {mulDyn}");
            Console.WriteLine($"Div : {divDyn}");
            Console.WriteLine($"Sub : {subDyn}");
            Console.WriteLine($"Zero : {zeroDyn}");


            #endregion

        }
    }
}
