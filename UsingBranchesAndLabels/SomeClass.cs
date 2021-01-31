using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingBranchesAndLabels
{
    class SomeClass
    {

        public static int Calculate(int x)
        {
            int result = 0;
            for (int i = 0; i < 10; i++)
            {
                result += i * x;
            }
            return result;
        }
    }
}
