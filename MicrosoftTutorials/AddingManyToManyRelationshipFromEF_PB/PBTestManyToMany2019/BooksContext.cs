using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBTestManyToMany2019
{
    public class BooksContext : DbContext
    {
        public BooksContext() : base("name=BooksDB")
        {
            Database.SetInitializer<BooksContext>(new DropCreateDatabaseIfModelChanges<BooksContext>());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Ref> Refs { get; set; }
        //public DbSet<BooksRefs> BooksRefs{ get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Book>()
        //        .HasMany<Book>(b=>b.Refs)
        //        .WithMany(r=>r.Books)
        //}
    }
}
