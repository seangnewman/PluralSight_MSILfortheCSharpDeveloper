using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstReflectionDemo
{
    class Person
    {
        public string Name { get; set; }

        public string Speak()
        {
            return string.Format($"Hello there, my name is {Name}");
        }
    }
}
