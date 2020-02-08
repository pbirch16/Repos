//01 https://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx
//Configure One-to-Zero-or-One Relationship in Entity Framework 6

//02 https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
//Configure One-to-Many Relationships in EF 6

//03 https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
//Configure Many-to-Many Relationships in Code-First
//See separate project "EF6ConsoleM2M02

//https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ConsoleM2M01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolDBContext())
            {
                var student = new Student() { StudentName = "Peter" };
                ctx.Students.Add(student);
                int ret = ctx.SaveChanges();
            }
        }
    }
}
