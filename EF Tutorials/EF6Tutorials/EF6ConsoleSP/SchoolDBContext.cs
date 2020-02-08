//https://www.entityframeworktutorial.net/entityframework6/code-first-insert-update-delete-stored-procedure-mapping.aspx
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ConsoleSP
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext() : base("PbScoolDbSP")
        {

        }        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .MapToStoredProcedures();

            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
    }
}
