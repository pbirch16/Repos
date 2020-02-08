using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbTestManyToMany3_CF
{
    public struct ProjectStructure
    {
        public int Id;
        public string Name;
    }

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

        public List<ProjectStructure> GetKeywordByProject(int keywordId)
        {
            var result = (
                    from p in _ctx.Keywords     //Instance from Context
                    from k in p.Projects        //Instance from navigation property
                    join pk in _ctx.Projects on k.Id equals pk.Id //Join to amalgamate relevant data
                    where p.Id == keywordId
                    select new ProjectStructure
                    {
                        Id = pk.Id,
                        Name = pk.ProjectName
                    }).ToList();

            foreach (var ps in result)
            {
                Console.WriteLine("ProjectId: {0} Project Name: {1}", ps.Id, ps.Name);
            }

            return result;
        }

    }
}
