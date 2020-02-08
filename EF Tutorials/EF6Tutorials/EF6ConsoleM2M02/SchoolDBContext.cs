using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF6ConsoleM2M02
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("PbScoolDbM2M02")
        {
    
        }

        public DbSet<Student>Students{ get; set; }
        public DbSet <Course>Courses{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                    {
                        cs.MapLeftKey("StudentRefId");
                        cs.MapRightKey("CourseRefId");
                        cs.ToTable("StudentCourse");
                    });

            //base.OnModelCreating(modelBuilder);
        }
    }
}
