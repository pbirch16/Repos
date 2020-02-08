//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
//Configure a Many-to-Many Relationship using Fluent API
using System.Data.Entity;

namespace Many2ManyExample01
{
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("name=CollegeDB")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

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