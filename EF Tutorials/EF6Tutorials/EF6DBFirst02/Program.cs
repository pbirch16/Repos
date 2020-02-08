//01 https://www.entityframeworktutorial.net/entityframework6/create-entity-data-model.aspx
//02 https://www.entityframeworktutorial.net/crud-operation-in-connected-scenario-entity-framework.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DBFirst02
{
    class Program
    {
        static void Main(string[] args)
        {
            //02
            using (var context = new SchoolDBEntities())
            {
                var s = context.Students.First<Student>();
                var name = s.StudentName;
                s.StudentName = "Peter";
                //var std = new Student()
                //{
                //    StudentName = "Bluebottle"
                //};

                //context.Students.Add(std);

                context.SaveChanges();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.WriteLine("Exiting");
        }
    }
}
