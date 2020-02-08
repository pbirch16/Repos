using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbTestManyToMany3_CF_Live
{
    class DisplayDatabaseData
    {
        private ProjectContext _ctx;

        public DisplayDatabaseData()
        {
            _ctx = new ProjectContext();
        }


        //Destructor
        ~DisplayDatabaseData()
        {
            _ctx.Dispose();
        }

        //public void GetKeywordByProject(int keywordId)
        //{
        //    var result =
        //            (
        //            from p in _ctx.Keywords     //Instance from Context
        //            from k in p.Projects        //Instance from navigation property
        //            join pk in _ctx.Projects on k.ProjectId equals pk.ProjectId //Join to amalgamate relevant data
        //            where p.KeywordId == keywordId
        //            select new ProjectObject()
        //            {
        //                ProjectId = pk.ProjectId,
        //                Name = pk.Name,
        //                Location = pk.Location
        //            }
        //            ).ToList();

        //    foreach (var ps in result)
        //    {
        //        Console.WriteLine("ProjectId: {0} | Name: {1} | Location: {2}", ps.ProjectId, ps.Name, ps.Location);

        //    }

        //    //return result;
        //}

        public void Display()
        {            
            List<Solution> lstSolutions = _ctx.Solutions.ToList();
            List<Project> lstProjects = new List<Project>();
            List<Keyword> lstKeywords = new List<Keyword>();
            List<Xref> lstXrefs = new List<Xref>();

            foreach (var s in lstSolutions)
            {
                Console.WriteLine("SolutionId: {0} | Name: {1} | Location: {2}", s.SolutionId, s.Name, s.Location);
                lstProjects = s.Projects.ToList();
                
                foreach (var p in lstProjects)
                {
                    Console.WriteLine("\tProjectId: {0} | Name: {1} | Location: {2}", p.ProjectId, p.Name, p.Location);
                    lstKeywords = p.Keywords.ToList();

                    foreach (var k in lstKeywords)
                    {
                        Console.WriteLine("\t\tKeywordId: {0} | Name: {1}", k.KeywordId, k.Name);
                    }

                    lstXrefs = p.Xrefs.ToList();
                    foreach (var x in lstXrefs)
                    {
                        Console.WriteLine("\t\tXrefId: {0} | Url: {1} | Description: {2}", x.XrefId, x.Url, x.Description);
                    }
                }
            }

            //foreach(var s in lstSolutions)
            //{
            //    Console.WriteLine("SolutionId: {0} | Name: {1} | Location: {2}", s.SolutionId, s.Name, s.Location);
            //    foreach (var p in lstProjects)
            //    {
            //        Console.WriteLine("\tProjectId: {0} | Name: {1} | Location: {2}", p.ProjectId, p.Name, p.Location);
            //        foreach (var k in lstKeywords)
            //        {
            //            Console.WriteLine("\t\tKeywordId: {0} | Name: {1}", k.KeywordId, k.Name);                        
            //        }

            //        foreach (var x in lstXrefs)
            //        {
            //            Console.WriteLine("\t\tXrefId: {0} | Url: {1} | Description: {2}", x.XrefId, x.Url, x.Description);
            //        }
            //    }
            //}
        }//Display
    }
}
