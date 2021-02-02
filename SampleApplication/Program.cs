using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Greet(args[0]);
        }

        private static void Greet(string name)
        {
            Console.WriteLine($"Greetings {name}");
        }
    }
}
