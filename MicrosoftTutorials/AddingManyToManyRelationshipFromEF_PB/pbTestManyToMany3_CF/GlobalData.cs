namespace pbTestManyToMany3_CF
{
    public struct DbDataStruct
    {
        public KeywordStruct keywordStruct;
        public ProjectStruct projectStruct;
        public SolutionStruct solutionStruct;
        public XRefStruct xRefStruct;
    }

    public struct KeywordStruct
    {
        public int Id;
        public int Name;        
    }

    public struct ProjectStruct
    {
        public int Id;
        public string Name;
        public string Location;
    }

    public struct SolutionStruct
    {
        public int Id;
        public string Name;
        public string Location;
    }

    public struct XRefStruct
    {
        public int Id;
        public string Url;
        public string Description;
    }
    class GlobalData
    {
    }
}
