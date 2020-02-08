namespace pbTestManyToMany3_CF
{
    public class XRef
    {
        public XRef()
        {
            this.Projects = new ObservableListSource<Project>();
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public virtual ObservableListSource<Project> Projects { get; set; }
    }
}
