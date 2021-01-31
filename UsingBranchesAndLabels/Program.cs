using System;
using System.Reflection.Emit;

namespace UsingBranchesAndLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SomeClass.Calculate(1000);

            Console.WriteLine(result);

            var calc = new DynamicMethod("CalcMethod",
                                                                            typeof(int),
                                                                            new[] { typeof(int) },
                                                                            typeof(Program).Module);

            var il = calc.GetILGenerator();
            // Define labels for loop and return from method
            var loopStart = il.DefineLabel();
            var methodEnd = il.DefineLabel();

            // variable 0 : result = 0
            il.DeclareLocal(typeof(int));               // declare local variable result
            il.Emit(OpCodes.Ldc_I4_0);                 // Create  local variable of Integer (4 bytes) with 0
            il.Emit(OpCodes.Stloc_0);                    // Store the local variable 

            // variable 1 : i = 0
            il.DeclareLocal(typeof(int));               // declare local variable result
            il.Emit(OpCodes.Ldc_I4_0);                 // Create  local variable of Integer (4 bytes) with 0
            il.Emit(OpCodes.Stloc_1);                    // Store the local variable 

            // Mark beginning of loop
            il.MarkLabel(loopStart);
            il.Emit(OpCodes.Ldloc_1);                   // value of i now on evaluation stack
            il.Emit(OpCodes.Ldc_I4, 10);              // Create local variable of Integer (4 bytes) with value of 10
            il.Emit(OpCodes.Bge, methodEnd);  // If i >= 10, jump to method end
            // i * x
            il.Emit(OpCodes.Ldloc_1);                   // Load value of i to evaluation stack
            il.Emit(OpCodes.Ldarg_0);                   // Load argument to evaluation stack
            il.Emit(OpCodes.Mul);                           // multiply i * x

            // result +=
            il.Emit(OpCodes.Ldloc_0);                   // Load result onto evailation stack
            il.Emit(OpCodes.Add);                           // Add result of multiplication (i) to local variable (result)
            il.Emit(OpCodes.Stloc_0);                     // Store result in local variable

            // increment i
            il.Emit(OpCodes.Ldloc_1);                       //Load value of i to evaluation stack
            il.Emit(OpCodes.Ldc_I4_1);                      // Load value of 1 to evaluation stack
            il.Emit(OpCodes.Add);                               // Increment
            il.Emit(OpCodes.Stloc_1);                            // ** Store the value i!!

            // Return to loop start
            il.Emit(OpCodes.Br, loopStart);

            // When i > 10
            il.MarkLabel(methodEnd);
            il.Emit(OpCodes.Ldloc_0);                       // Load result to evaluation stack
            il.Emit(OpCodes.Ret);                               // Return from method

            // Create the delegate 
            var method = (Func<int, int>)calc.CreateDelegate(typeof(Func<int,   // Parameter 1 
                                                                                                        int     // Return type
                                                                                                        >));

            var result2 = method(1000);
            Console.WriteLine(result);
        }
    }
}
