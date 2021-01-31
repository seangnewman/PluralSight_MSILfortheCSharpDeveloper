using System;
using System.Reflection.Emit;

namespace MySecondILDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcMethod = new DynamicMethod("CalcMethod",   
                                                                                            typeof(int),
                                                                                            new[] { typeof(int), typeof(int), typeof(int) },
                                                                                            typeof(Program).Module);

            var il = calcMethod.GetILGenerator();
            il.DeclareLocal(typeof(int));                   // Declare type of local variable to store product
                
            il.Emit(OpCodes.Ldarg_0);                       // Add first parameter to evaluation stack
            il.Emit(OpCodes.Ldarg_1);                       // Add second parameter to evaluation stack
            il.Emit(OpCodes.Mul);                               // Pop the first two parameters,
            
            il.Emit(OpCodes.Stloc_0);                        // store the product to local variable 
            il.Emit(OpCodes.Ldloc_0);                       // Load the local variable to the evaluation stack
            il.Emit(OpCodes.Ldarg_2);                      // Load third parameter to evaluation stack
            il.Emit(OpCodes.Sub);                               // Pop third parameter and local variable from evaluation stack
            il.Emit(OpCodes.Ret);                               // Return from method

            // Create delegate to correspond to signature of DynamicMethod
            var method = (Func<int, int, int, int>)calcMethod.CreateDelegate(typeof(Func<int,   // Parameter 1
                                                                                                                                                                     int,   // Parameter 2
                                                                                                                                                                    int,   // Parameter 3
                                                                                                                                                                     int    // Return type
                                                                                                                                                                     >));

            var result = method(10, 10, 5);

            Console.WriteLine(result);
        }


        static int Calculate(int first, int second, int third)
        {
            var result = first * second;
            return result - third;
        }
    }
}
