using System.Data.Entity;
using System.Linq;
//public struct ProjectStruct
//{
//    public string Id;
//    public string Name;
//    public string Location;
//}

//public struct SolutionStruct
//{
//    public int Id;
//    public string Name;
//    public string Location;
//}

//public struct KeywordStruct
//{
//    public int Id;
//    public string Name;    
//}

//public struct RefStruct
//{
//    public int Id;
//    public string Url;
//    public string Description;
//}

//https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework

namespace pbTestManyToMany3_CF
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

        public void CreateXRef(XRef xRef)
        {
                _ctx.SaveChanges();
        }
        #endregion CREATE

        #region READ
        #endregion READ

        #region LINK

        public void LinkProjectToSolution(int projectId, int solutionId)
        {
            var p = _ctx.Projects.FirstOrDefault(p => p.Id == projectId);
            var s = _ctx.Solutions.Find(solutionId);
            s.Projects.Add(p);
            _ctx.SaveChanges();
        }
        public void LinkProjectToKeyword(int projectId,int keywordId)
        {
            var p = _ctx.Projects.Find(projectId);
            var k = _ctx.Keywords.Find(keywordId);
            _ctx.Keywords.Attach(k);
            p.Keywords.Add(k);
            _ctx.SaveChanges();
        }

        public void LinkProjectToXRef(int projectId, int xRefId)
        {
            var p = _ctx.Projects.Find(projectId);
            var x = _ctx.XRefs.Find(xRefId);
            _ctx.XRefs.Attach(x);
            p.XRefs.Add(x);
            _ctx.SaveChanges();
        }

        #endregion LINK


        #region UPDATE
        #endregion UPDATE

        
        #region Delink
        //This is only 1 to Many, not Many to Many (Hence only one solution to find)
        public void DelinkProjectFromSolution(int projectId, int solutionId)
        {                        
            var p = _ctx.Projects.FirstOrDefault(p => p.Id == projectId);
            var s = _ctx.Solutions.Find(solutionId);
            s.Projects.Remove(p);
            _ctx.SaveChanges();
        }

        public void DelinkProjectFromKeyword(int projectId, int keywordId)
        {
            //Return one instance of each entity by Primary Key
            var project = _ctx.Projects.FirstOrDefault(p => p.Id == projectId);
            var keyword = _ctx.Keywords.FirstOrDefault(k => k.Id == keywordId);
            project.Keywords.Remove(keyword);
            _ctx.SaveChanges();
        }

        public void DelinkProjectFromXRef(int projectId, int xRefId)
        {
            //Return one instance of each entity by Primary Key
            var project = _ctx.Projects.FirstOrDefault(p => p.Id == projectId);
            var xRef = _ctx.Keywords.FirstOrDefault(x => x.Id == xRefId);
            project.Keywords.Remove(xRef);
            _ctx.SaveChanges();
        }
        #endregion Delink

        #region DELETE

        #endregion DELETE






    }
}
