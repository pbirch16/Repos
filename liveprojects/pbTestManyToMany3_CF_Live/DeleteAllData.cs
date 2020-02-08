using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbTestManyToMany3_CF_Live
{
    class DeleteAllData
    {
        private ProjectContext _ctx;
        public DeleteAllData()
        {
            _ctx = new ProjectContext();
        }

        ~DeleteAllData()
        {
            _ctx.Dispose();
        }

        public void ProcessDelete()
        {
            List<Solution> lstSolutions = _ctx.Solutions.ToList();
            List<Project> lstProjects;
            List<Keyword> lstKeywords;
            List<Xref> lstXrefs;

            foreach (var s in lstSolutions)
            {
                lstProjects = s.Projects.ToList();
                foreach (var p in lstProjects)
                {
                    lstKeywords = p.Keywords.ToList();
                    lstXrefs = p.Xrefs.ToList();
                    foreach (var k in lstKeywords)
                    {
                        k.Projects.Remove(p);   //Remove Navigation Property                        
                    }

                    foreach (var x in lstXrefs)
                    {
                        x.Projects.Remove(p);   //Remove Navigation Property 
                    }
                }
            }


            foreach (var k in _ctx.Keywords)
            {
                _ctx.Keywords.Remove(k);
            }

            foreach (var x in _ctx.Xrefs)
            {
                _ctx.Xrefs.Remove(x);
            }

            foreach (var p in _ctx.Projects)
            {
                _ctx.Projects.Remove(p);
            }

            foreach (var s in _ctx.Solutions)
            {
                _ctx.Solutions.Remove(s);
            }

            _ctx.SaveChanges();
            MessageBox.Show("Some records deleted");
        }
    }
}


//context.Database.ExecuteSqlCommand("TRUNCATE TABLE [TableName]");