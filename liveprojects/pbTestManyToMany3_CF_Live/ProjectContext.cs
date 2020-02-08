using System.Data.Entity;

namespace pbTestManyToMany3_CF_Live
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=CSProjectsDB")
        {

        }

        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Xref> Xrefs { get; set; }
        public DbSet<Solution> Solutions { get; set; }
    }
}
