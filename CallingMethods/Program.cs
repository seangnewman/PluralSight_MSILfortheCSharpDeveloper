using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CallingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Calling Methods
            //Print(42);

            //var myMethod = new DynamicMethod("MyMethod",
            //                                                                            typeof(void),                   // Return type
            //                                                                            null,
            //                                                                             typeof(Program).Module);

            //var il = myMethod.GetILGenerator();

            //// Place value 42 on evaluation stack
            //il.Emit(OpCodes.Ldc_I4, 42);
            //// Call the method
            //il.Emit(OpCodes.Call, typeof(Program).GetMethod("Print"));
            //il.Emit(OpCodes.Ret);

            ////create delegate
            //var myMethodDelegate = (Action)myMethod.CreateDelegate(typeof(Action));
            //myMethodDelegate();
            #endregion

            #region Calling Dynamic Methods
            // Create a method that takes a parameter and  multiplies by 42
            var multiplyMethod = new DynamicMethod("MultiplyMethod",
                                                                                                   typeof(int),                 // Return an integer value
                                                                                                   new[] { typeof(int) },    // Pass one parameter
                                                                                                   typeof(Program).Module);

            var multiplyMethodIL = multiplyMethod.GetILGenerator();

            multiplyMethodIL.Emit(OpCodes.Ldarg_0);                 // Pushes the argument to evaluation stack 
            multiplyMethodIL.Emit(OpCodes.Ldc_I4, 42);             // Places value of 42 on evaluation stack
            multiplyMethodIL.Emit(OpCodes.Mul);                         // Pops last two values  and multipies
            multiplyMethodIL.Emit(OpCodes.Ret);                          // Return from function


            //// Create delegate for function
            //var multiplyMethodDelegate = (Func<int, int>)multiplyMethod.CreateDelegate(typeof(Func<int,   // First argument
            //                                                                                                                                                                                    int     // Return type
            //                                                                                                                                                                                    >));

            //var result = multiplyMethodDelegate(10);
            //Console.WriteLine(result);

            // Create signature of method
            var calculateMethod = new DynamicMethod("CalculateMethod",
                                                                                                    typeof(int),                                            // Returning integer
                                                                                                    new[] { typeof(int), typeof(int) },     // Accepts two parameters
                                                                                                    typeof(Program).Module);

            var calcMethodIL = calculateMethod.GetILGenerator();
            calcMethodIL.Emit(OpCodes.Ldarg_0);                 // Push arg 1 to the evaluation stack
            calcMethodIL.Emit(OpCodes.Ldarg_1);                 // Push arg 2 to the evaluation stack
            calcMethodIL.Emit(OpCodes.Mul);                         // Pop the two values and multiply,  product on the evaluation stack

            calcMethodIL.Emit(OpCodes.Call, multiplyMethod);   // Call multiply method, which multiplies product by 42
            calcMethodIL.Emit(OpCodes.Ret);                                     // Return from method

            // Create the delegate
            var calcMethodDelegate = (Func<int, int, int>)calculateMethod.CreateDelegate(typeof(Func<int,      // First argument
                                                                                                                                                                                                int,      // Second argument
                                                                                                                                                                                                int       // Return type
                                                                                                                                                                                                 >));
            var result = calcMethodDelegate(100, 100);
            Console.WriteLine(result);




            #endregion


        }

        public static void Print(int i)
        {
            Console.WriteLine("The value passed to Print is {0}", i);
        }
    }
}
