//https://www.entityframeworktutorial.net/code-first/setup-entity-framework-code-first-environment.aspx

namespace EF6Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolDBContext())
            {
                var stud = new Student() { StudentName = "Cecilia" };
                ctx.Students.Add(stud);
                ctx.SaveChanges();
            }
        }


    }





}
