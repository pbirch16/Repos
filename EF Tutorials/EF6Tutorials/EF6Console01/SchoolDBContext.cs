using System.Data.Entity;

namespace EF6Console01
{
    public class SchoolDBContext : DbContext
    {
        //public SchoolDBContext() : base("PbSchoolDb04") //02, 04
        public SchoolDBContext() : base("Pb5ConnectionString")
        {
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
