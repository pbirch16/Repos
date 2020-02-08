using System.Collections.Generic;
using System.Data.Entity;

namespace EF6Console
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("PbSchoolDB")
        {
            //Database.SetInitializer<SchoolContext>(new CreateDatabaseIfNotExists<SchoolContext>());
            //Database.SetInitializer<SchoolContext>(new DropCreateDatabaseIfModelChanges<SchoolContext>());
            Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolContext>(new SchoolDBInitializer());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<StudentAddress> StudentAddress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Admin");
            //base.OnModelCreating(modelBuilder);

            //Configure primary key
            modelBuilder.Entity<Student>().HasKey<int>(s => s.StudentID);
            modelBuilder.Entity<Standard>().HasKey<int>(s => s.StandardKey);

            //Configure composite primary key
            modelBuilder.Entity<Student>().HasKey(s => new { s.StudentID, s.StudentName });

            //Configure Column
            modelBuilder.Entity<Student>()
                .Property(p => p.DateOfBirth)
                .HasColumnName("DoB")
                .HasColumnOrder(3)
                .HasColumnType("datetime2");

            //Configure Null Column
            modelBuilder.Entity<Student>()
                .Property(p => p.Height)
                .IsOptional();

            //Configure NotNull Column
            modelBuilder.Entity<Student>()
                .Property(p => p.Weight)
                .IsRequired();

            //Configure Student and StudentAddress Entity
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.Address)  //Mark Address property optional
                .WithRequired(ad => ad.Student);    //Mark Student property as required in StudentAddress entity.
                                                    //Cannot save StudentAddress without Student
        }
    }
}
