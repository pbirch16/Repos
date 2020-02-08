//https://www.tutorialsteacher.com/linq/linq-lambda-expression
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{


    class Program
    {
        public delegate bool FilterDelegate(Person p);
        //Example: Anonymous Method
        //delegate (Student s) { return s.Age > 12 && s.Age< 20; };

        static void Main(string[] args)
        {
            Person p1 = new Person() { Name = "John", Age = 41 };
            Person p2 = new Person() { Name = "Jane", Age = 69 };
            Person p3 = new Person() { Name = "Jake", Age = 12 };
            Person p4 = new Person() { Name = "Jessie", Age = 25 };

            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

            //
            Console.ReadKey();
        }
    }
}
