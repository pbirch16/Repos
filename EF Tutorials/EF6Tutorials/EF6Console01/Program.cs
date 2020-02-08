//01 https://www.entityframeworktutorial.net/code-first/setup-entity-framework-code-first-environment.aspx
//02 https://www.entityframeworktutorial.net/code-first/database-initialization-in-code-first.aspx
//03 https://www.entityframeworktutorial.net/code-first/configure-classes-in-code-first.aspx
//04 https://www.entityframeworktutorial.net/code-first/dataannotation-in-code-first.aspx

using System;
using System.Configuration;

namespace EF6Console01
{
    class Program
    {
        static void Main()
        {
            init();

            using (var ctx = new SchoolDBContext())
            {
                var stud = new Student() { StudentName = "Cecilia Birch" };

                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }

        static void init()
        {
            //var cm = ConfigurationManager.AppSettings["DataDirectory"];
            //var cs = ConfigurationManager.ConnectionStrings;

            //var dd = AppDomain.CurrentDomain.GetData("DataDirectory");
        }
    }
}
