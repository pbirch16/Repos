//https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbTestManyToMany3_CF_Live
{
    class CrudPlus
    {
        private ProjectContext _ctx;
        public CrudPlus(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        ~CrudPlus()
        {
            _ctx.Dispose();
        }

        #region CREATE
        public void CreateKeyword(Keyword keyword)
        {
            _ctx.Keywords.Add(keyword);
            _ctx.SaveChanges();
        }
        public void CreateProject(Project project)
        {
            _ctx.Projects.Add(project);
            _ctx.SaveChanges();
        }

        public void CreateSolution(Solution solution)
        {
            _ctx.Solutions.Add(solution);
            _ctx.SaveChanges();
        }

        public void CreateXRef(Xref xref)
        {
            _ctx.SaveChanges();
        }
        #endregion CREATE

        #region READ
        #endregion READ

        #region LINK

        public void LinkProjectToSolution(int projectId, int solutionId)
        {
            var proj = _ctx.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            var soln = _ctx.Solutions.Find(solutionId);
            soln.Projects.Add(proj);
            _ctx.SaveChanges();
        }
        public void LinkProjectToKeyword(int projectId, int keywordId)
        {
            var p = _ctx.Projects.Find(projectId);
            var k = _ctx.Keywords.Find(keywordId);
            _ctx.Keywords.Attach(k);
            p.Keywords.Add(k);
            _ctx.SaveChanges();
        }

        public void LinkProjectToXRef(int projectId, int xrefId)
        {
            var p = _ctx.Projects.Find(projectId);
            var x = _ctx.Xrefs.Find(xrefId);
            _ctx.Xrefs.Attach(x);
            p.Xrefs.Add(x);
            _ctx.SaveChanges();
        }

        #endregion LINK


        #region UPDATE
        #endregion UPDATE


        #region Delink
        //This is only 1 to Many, not Many to Many (Hence only one solution to find)
        public void DelinkProjectFromSolution(int projectId, int solutionId)
        {
            var project = _ctx.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            var soln = _ctx.Solutions.Find(solutionId);
            soln.Projects.Remove(project);
            _ctx.SaveChanges();
        }

        public void DelinkProjectFromKeyword(int projectId, int keywordId)
        {
            //Return one instance of each entity by Primary Key
            var project = _ctx.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            var keyword = _ctx.Keywords.FirstOrDefault(k => k.KeywordId == keywordId);
            project.Keywords.Remove(keyword);
            _ctx.SaveChanges();
        }

        public void DelinkProjectFromXRef(int projectId, int xrefId)
        {
            //Return one instance of each entity by Primary Key
            var project = _ctx.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            var Xref = _ctx.Keywords.FirstOrDefault(x => x.KeywordId == xrefId);
            project.Keywords.Remove(Xref);
            _ctx.SaveChanges();
        }
        #endregion Delink

        #region DELETE

        #endregion DELETE
    }
}
