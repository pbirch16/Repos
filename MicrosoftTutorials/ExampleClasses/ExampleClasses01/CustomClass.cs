//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleClasses01
{
    public class CustomClass
    {
        //Class members
        //

        //Property
        public int Number { get; set; }

        //Method
        public int Mutiply(int num)
        {
            return num * Number;
        }

        //Instance Constructor
        public CustomClass()
        {
            Number = 0;
        }
    }
}
