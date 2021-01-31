using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMethods
{
    class Factorial
    {
        public static int Calculate(int i)
        {
            if (i == 1 )
            {
                return i;
            }

            return i * Calculate(i - 1);
        }

         
	 
    }
}
