namespace pbTestManyToMany3_CF_Live
{
    public class Xref
    {
        public Xref()
        {
            this.Projects = new ObservableListSource<Project>();
        }
        public int XrefId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public virtual ObservableListSource<Project> Projects { get; set; }
    }
}
