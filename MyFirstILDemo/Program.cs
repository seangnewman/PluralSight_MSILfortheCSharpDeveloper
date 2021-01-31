using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstILDemo
{
    class Program
    {

        delegate double DivideDelegate(int a, int b);
        static void Main(string[] args)
        {

            //var result = Divider(10, 2);
            //Console.WriteLine(result);

            var myMethod = new DynamicMethod("DivideMethod", 
                                                                                        typeof(double), 
                                                                                        new[] { typeof(int), typeof(int) }, 
                                                                                        typeof(Program).Module);
            var il = myMethod.GetILGenerator();

           // Load the parameters to the evaluation stack
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);

            //Perform division with two values on evaluation stack
            il.Emit(OpCodes.Div);   // Return result to evaluation stack

            il.Emit(OpCodes.Ret);  //Return from method


            // Method 1
            var result = myMethod.Invoke(null, new object[] { 10,2});
            Console.WriteLine(result);

            // Method 2 - Create delegate
            var method = (DivideDelegate)myMethod.CreateDelegate(typeof(DivideDelegate));
            var result2 = method(6, 2);
            Console.WriteLine(result2);


                
          }

        static double Divider(int a, int b)
        {
            return a / b;
                        
        }
    }
}
