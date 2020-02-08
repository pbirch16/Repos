using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF6ConsoleM2M01
{
    public class SchoolDBContext : DbContext
    {
        //01 PbSchoolDb1To1
        //02 PbSchoolDb1ToM
        public SchoolDBContext() : base("PbSchoolDb1ToM")
        {

        }

        //Configure a One-to-Zero-or-One relationship using Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Address) //Mark Address property optional
                .WithRequiredPrincipal(ad => ad.Student);    //Mark Student property as required

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses{ get; set; }
    }
}
