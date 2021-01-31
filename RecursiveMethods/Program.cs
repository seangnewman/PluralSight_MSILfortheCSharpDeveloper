using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMethods
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = Factorial.Calculate(5);
            Console.WriteLine(result);

            #region Dynamic Method

            var factorial = new DynamicMethod("Factorial",
                                                                                    typeof(int),
                                                                                    new [] {typeof(int)},
                                                                                    typeof(Program).Module
                                                                                    );

            var il = factorial.GetILGenerator();

            var methodEnd = il.DefineLabel();                   // Create a label for the base case
            // If i = 1
            // Load i twice as it is used in the multiplication and subtraction
            il.Emit(OpCodes.Ldarg_0);                                   // Place the argument on the evaluation stack
            il.Emit(OpCodes.Ldarg_0);                                   // Place the argument again as we compare against each time

            il.Emit(OpCodes.Ldc_I4_1);                                 // Load the value 1 to the evaluation stack
            il.Emit(OpCodes.Beq, methodEnd);                    // Pops value 1 and value i from stack, If i ==1 , then Branch to methodEnd 

            il.Emit(OpCodes.Ldc_I4_1);                                  // Load value of 1 to stack
            il.Emit(OpCodes.Sub);                                           // Pops value 1 and second value i from stack, places result on evalution stack
            il.Emit(OpCodes.Call, factorial);                          // Pass the  factorial on evaluation stack

            il.Emit(OpCodes.Ldarg_0);                                    // Load the argument on the evaluation stack  , this is now i - 1   
             il.Emit(OpCodes.Mul);                                           // This pops the value of i and the value of factorial, result is placed on evaluation stack

            il.MarkLabel(methodEnd);                                    // This is method end

            il.Emit(OpCodes.Ret);                                               // return from the method

            // Create the delegate
            var factorialDelegate = (Func<int, int>)factorial.CreateDelegate(typeof(Func<int, int>));

            var result2 = factorialDelegate(5);

            Console.WriteLine(result2);
            #endregion
        }
    }
}
