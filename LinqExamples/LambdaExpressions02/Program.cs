//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions?view=netframework-4.8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions02
{
    class Program
    {
        static void Main(string[] args)
        {
            LE01();

            Console.ReadKey();
        }

        static void LE01()
        {
            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);
        }

    }
}


