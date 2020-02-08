//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspxusing System;
//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms

namespace EFT_ConfigureManyToManyDefaultJT
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolDBContext())
            {
                Student s = new Student { StudentName = "Peter" };

                ctx.Students.Add(s);
                ctx.SaveChanges();
            }
        }
    }
}
