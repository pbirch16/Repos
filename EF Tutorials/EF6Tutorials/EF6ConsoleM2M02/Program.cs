//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ConsoleM2M02
{
    class Program
    {
        static void Main()
        {
            using (var ctx = new SchoolDBContext())
            {
                var student = new Student() { StudentName = "Bluebottle" };
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
        }
    }
}
