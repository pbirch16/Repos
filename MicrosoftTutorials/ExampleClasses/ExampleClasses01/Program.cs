//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleClasses01
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex01();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void Ex01()
        {
            CustomClass custClass = new CustomClass();
            custClass.Number = 27;

            int result = custClass.Mutiply(4);

            Console.WriteLine($"The result is {result}.");
        }

        //Classes(C# Programming Guide)
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
        static void Ex02()
        {

        }
    }
}
