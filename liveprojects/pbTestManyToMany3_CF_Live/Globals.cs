using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbTestManyToMany3_CF_Live
{
    public struct DbDataStruct
    {
        public KeywordObject keywordObject;
        public ProjectObject projectObject;
        public SolutionObject solutionObject;
        public XrefObject xrefObject;
    }

    //public struct KeywordStruct
    //{
    //    public int KeywordId;
    //    public int Name;
    //}

    //public struct ProjectStruct
    //{
    //    public int ProjectId;
    //    public string Name;
    //    public string Location;
    //    public ProjectStruct(int projectId, string name, string location)
    //    {
    //        ProjectId = projectId;
    //        Name = name;
    //        Location = location;
    //    }
    //}

    //public struct SolutionStruct
    //{
    //    public int SolutionId;
    //    public string Name;
    //    public string Location;
    //}

    //public struct XrefStruct
    //{
    //    public int XrefId;
    //    public string Url;
    //    public string Description;
    //}


    class Globals
    {
    }
}
