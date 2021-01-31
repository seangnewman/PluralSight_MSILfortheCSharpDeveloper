using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sean = new Person { Name = "Sean Newman" };

            //Console.WriteLine(sean.Speak());

            var type = sean.GetType(); // Returns type information for Person class
            var methods = type.GetMethods();   // Returns an array of method info

            //foreach (var method in methods)
            //{
            //    Console.WriteLine(method.Name);
            //    // Person name inherits from object
            //}

            type.GetMethod("set_Name").Invoke(sean, new[] { "Johan" });  // Change value of person instance
           var result =  type.GetMethod("Speak").Invoke(sean, null);  // Null used as no parameters are defined for Speak()

            Console.WriteLine(result);



        }
    }
}
