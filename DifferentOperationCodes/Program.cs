using System;
using System.Reflection.Emit;

namespace DifferentOperationCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DivAndRemainder
            //     //var myMethod = new DynamicMethod("MyMethod", 
            //     //                                                                            typeof(double), 
            //     //                                                                            new[] { typeof(int), typeof(int)},
            //     //                                                                            typeof(Program).Module);

            //     var myMethod = new DynamicMethod("MyMethod",
            //                                                                                typeof(double),
            //                                                                                new[] { typeof(int), typeof(int) }
            //                                                                                /* By omiting typeof(Program).Module this becomes anonymously hosted */);

            //     var il = myMethod.GetILGenerator();

            //     il.Emit(OpCodes.Ldarg_0);
            //     il.Emit(OpCodes.Conv_R4);                   // Converts integer to float
            //     il.Emit(OpCodes.Ldarg_1);
            //     il.Emit(OpCodes.Conv_R4);                   // Converts integer to float
            //     //il.Emit(OpCodes.Div);
            //     il.Emit(OpCodes.Rem);
            ////     il.Emit(OpCodes.Conv_R4);                 // Converts value to float - We should get dividebyzero error
            //     il.Emit(OpCodes.Ret);

            //     var method = (Func<int, int, double>) myMethod.CreateDelegate(typeof(Func<int, int, double>));

            //     var result = method(2, 10);      // Division by zero...  but does not cause exception... display infinity sign

            //     Console.WriteLine(result);
            #endregion
            #region NegatingValues

            // var myMethod = new DynamicMethod("MyMethod", 
            //                                                                             typeof(int),
            //                                                                             new[] { typeof(int)},
            //                                                                             typeof(Program).Module );

            // var il = myMethod.GetILGenerator();

            // il.Emit(OpCodes.Ldarg_0);
            // il.Emit(OpCodes.Neg);
            //// il.Emit(OpCodes.Mul);
            // il.Emit(OpCodes.Ret);

            // var method = (Func<int, int>)myMethod.CreateDelegate(typeof(Func<int, int>));

            // var result = method(2);

            // Console.WriteLine(result);
            #endregion
            #region Bitwise Operations
            //// 8 4 2 1
            //// ---------
            //// 0 1 0 0 = 4
            //// 0 0 1 0 = 2
            //// 0 1 1 0 = 6

            //var x = 4 & 6;
            //Console.WriteLine(x);
            //Console.WriteLine("-------------   Dynamic Method -------------");
            //var myMethod = new DynamicMethod("MyMethod", 
            //                                                                                typeof(int),
            //                                                                                new[] { typeof(int), typeof(int)},
            //                                                                                typeof(Program).Module);

            //var il = myMethod.GetILGenerator();

            //il.Emit(OpCodes.Ldarg_0);
            //il.Emit(OpCodes.Ldarg_1);
            //il.Emit(OpCodes.And);

            //il.Emit(OpCodes.Ret);

            //var method = (Func<int, int, int>)myMethod.CreateDelegate(typeof(Func<int, int, int>));
            //var result = method(4, 6);
            //Console.WriteLine(result);


            #endregion
            #region Creationg an Instance of a Class
            //var myMethod = new DynamicMethod("MyMethod",
            //                                                                            typeof(Person),
            //                                                                            Type.EmptyTypes,
            //                                                                            typeof(Program).Module);

            //var il = myMethod.GetILGenerator();

            //il.Emit(OpCodes.Newobj, typeof(Person).GetConstructor(Type.EmptyTypes));                // Create a new object, instantiate with the Constructor, passing no parameters (Type.EmptyTypes
            //il.Emit(OpCodes.Ret);

            //var getPersonMethod = (Func<Person>)myMethod.CreateDelegate(typeof(Func<Person>));
            //var result = getPersonMethod();
            //Console.WriteLine(result.Name);
            #endregion

            #region Loading Elements from Array
            var myMethod = new DynamicMethod("MyMethod", typeof(int), new[] { typeof(int[]) });

            var il = myMethod.GetILGenerator();

            // Reference to array
            il.Emit(OpCodes.Ldarg_0);                           // Reference to array now on evaluation stack
            il.Emit(OpCodes.Ldc_I4_2);                          // The index to begin 
            // Multiply the first two indexes
            il.Emit(OpCodes.Ldelem_I4);                     // Loads the element from the array from the position specified by the index

            // Reference to array
            il.Emit(OpCodes.Ldarg_0);                           // Reference to array now on evaluation stack
            il.Emit(OpCodes.Ldc_I4_3);                          // The index to begin 
            // Multiply the first two indexes
            il.Emit(OpCodes.Ldelem_I4);                     // Loads the element from the array from the position specified by the index

            // Array value from index 0 and index 1 now on the evaluation stack

            il.Emit(OpCodes.Mul);                               // Multiply the two values
            il.Emit(OpCodes.Ret);                               // Return

            var myMethodDelegate = (Func<int[], int>)myMethod.CreateDelegate(typeof(Func<int[], int>));


            var result = myMethodDelegate(new[] { 7, 3, 21, 3 });

            Console.WriteLine(result);

            #endregion
        }
    }
}
