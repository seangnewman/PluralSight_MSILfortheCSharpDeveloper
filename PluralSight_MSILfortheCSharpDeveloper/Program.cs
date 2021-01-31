using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight_MSILfortheCSharpDeveloper
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  Decompiling a C# Application
            //var x = 10;
            //var y = 20;

            //var result = x + y;
            #endregion

            #region What the method realy lookslike
            Console.WriteLine(Calculate(5));
            #endregion


        }

        private static int Calculate(int x)
        {
            int total = 0;

            for (int i = 5; i <= x; i+= 5)
            {
                total += i;
                if (total >= x)
                    break;
            }

            return total;
        }
    }
}
