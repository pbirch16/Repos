﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pbTestManyToMany_DBF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectsEntities1 : DbContext
    {
        public ProjectsEntities1()
            : base("name=ProjectsEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectsKeyword> ProjectsKeywords { get; set; }
        public virtual DbSet<ProjectsRef> ProjectsRefs { get; set; }
        public virtual DbSet<Ref> Refs { get; set; }
        public virtual DbSet<Solution> Solutions { get; set; }
    }
}