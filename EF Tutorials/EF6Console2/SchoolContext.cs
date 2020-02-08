using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console2
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("PBSchoolDB02")
        {
            Database.SetInitializer<SchoolContext>(new SchoolDBInitializer());
            
            //Database.SetInitializer<SchoolContext>(new CreateDatabaseIfNotExists<SchoolContext>());
            //Database.SetInitializer<SchoolContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolContext>(new DropCreateDatabaseAlways<SchoolContext>());
            //Database.SetInitializer<SchoolContext>(new SchoolDBInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            modelBuilder.Configurations.Add(new StudentConfigurations());

            modelBuilder.Entity<Teacher>()
                .ToTable("TeacherInfo");

            modelBuilder.Entity<Teacher>()
                .MapToStoredProcedures();

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }        
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
