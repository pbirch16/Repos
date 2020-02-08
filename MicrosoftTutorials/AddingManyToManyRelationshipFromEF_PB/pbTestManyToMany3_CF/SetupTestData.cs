//https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
//CRUD Many-to-Many Entity Framework
using System.Windows.Forms;

public struct DatabaseData
{
    public string KeywordName;

    public string ProjectName;
    public string ProjectLocation;

    public string ReferenceUrl;
    public string ReferenceDescription;

    public string SolutionName;
    public string SolutionLocation;
}



namespace pbTestManyToMany3_CF
{
    class SetupTestData
    {
        private ProjectContext _ctx;

        public SetupTestData()
        {
            _ctx = new ProjectContext();
            var dd = new DatabaseData
            {
                KeywordName = "Key Word 01",
                ProjectLocation = "Project Location 01",
                ProjectName = "Project Name 01",
                ReferenceDescription = "Ref Description 01",
                ReferenceUrl = "Ref URL 01",
                SolutionLocation = "Solution Location 01",
                SolutionName = "Solution Name 01"
            };
            InsertNewData(dd);
        }


        private void CleanUp()
        {
            _ctx.Dispose();
        }


        private void InsertNewData(DatabaseData dd)
        {
            Keyword k = new Keyword();
            k.Name = dd.KeywordName;

            Project p = new Project();
            p.ProjectName = dd.ProjectName;
            p.Location = dd.ProjectLocation;

            XRef r = new XRef();
            r.Url = dd.ReferenceUrl;
            r.Description = dd.ReferenceDescription;

            Solution s = new Solution();
            s.Name = dd.SolutionName;
            s.Location = dd.SolutionLocation;

            _ctx.Keywords.Add(k);
            _ctx.Projects.Add(p);
            _ctx.XRefs.Add(r);
            _ctx.Solutions.Add(s);

            //add instances to navigation propeties
            k.Projects.Add(p);

            p.Keywords.Add(k);
            p.XRefs.Add(r);

            r.Projects.Add(p);

            s.Projects.Add(p);

            _ctx.SaveChanges();

            CleanUp();
            MessageBox.Show("Test Data inserted");
        }
    }
}
