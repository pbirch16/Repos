using System.Data.Entity;

namespace pbTestManyToMany3_CF
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=CSProjects01DB")
        {

        }

        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<XRef> XRefs { get; set; }
        public DbSet<Solution> Solutions { get; set; }

    }
}
