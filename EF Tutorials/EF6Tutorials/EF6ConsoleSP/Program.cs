using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ConsoleSP
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolDBContext())
            {
                var student = new Student() { StudentName = "Peter", DoB = new DateTime(1940, 11, 17) };
                ctx.Students.Add(student);
                int ret = ctx.SaveChanges();
            }
        }
    }
}
