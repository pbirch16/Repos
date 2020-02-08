namespace pbTestManyToMany3_CF_Live
{
    public class Project
    {
        public Project()
        {
            this.Keywords = new ObservableListSource<Keyword>();
            this.Xrefs = new ObservableListSource<Xref>();
        }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public int SolutionId{ get; set; }
        public virtual Solution Solution{ get; set; }


        public virtual ObservableListSource<Keyword> Keywords { get; set; }
        public virtual ObservableListSource<Xref> Xrefs { get; set; }
    }
}
