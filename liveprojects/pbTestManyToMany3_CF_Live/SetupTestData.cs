//https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
//CRUD Many-to-Many Entity Framework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbTestManyToMany3_CF_Live
{
    public struct DatabaseDataStruct
    {
        public string KeywordName;

        public string ProjectName;
        public string ProjectLocation;

        public string XrefUrl;
        public string XrefDescription;

        public string SolutionName;
        public string SolutionLocation;
    }

    class SetupTestData
    {
        private ProjectContext _ctx;
        private DatabaseDataStruct _dds;

        public SetupTestData()
        {
            _ctx = new ProjectContext();
            ProcessData();
        }


        ~SetupTestData()
        {
            _ctx.Dispose();
        }

        private void ProcessData()
        {            
            for (int i = 1; i < 5; i++)
            {
                string num = i.ToString();
                _dds.KeywordName = "KW" + num;
                _dds.ProjectName = "PN" + num;
                _dds.ProjectLocation = "PL" + num;
                _dds.XrefUrl = "XU" + num;
                _dds.XrefDescription = "XD" + num;
                _dds.SolutionName = "SN" + num;
                _dds.SolutionLocation = "SL" + num;
                
                InsertNewData();                
            }
            MessageBox.Show("Test Data inserted");
        }


        private void InsertNewData()
        {
            Keyword k = new Keyword();
            k.Name = _dds.KeywordName;

            Project p = new Project();
            p.Name = _dds.ProjectName;
            p.Location = _dds.ProjectLocation;

            Xref r = new Xref();
            r.Url = _dds.XrefUrl;
            r.Description = _dds.XrefDescription;

            Solution s = new Solution();
            s.Name = _dds.SolutionName;
            s.Location = _dds.SolutionLocation;

            _ctx.Keywords.Add(k);
            _ctx.Projects.Add(p);
            _ctx.Xrefs.Add(r);
            _ctx.Solutions.Add(s);

            //add instances to navigation propeties
            k.Projects.Add(p);

            p.Keywords.Add(k);
            p.Xrefs.Add(r);

            r.Projects.Add(p);

            s.Projects.Add(p);

            _ctx.SaveChanges();                       
        }
    }//class
}//ns

