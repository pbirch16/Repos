namespace pbTestManyToMany3_CF_Live
{
    public class Keyword
    {
        public Keyword()
        {
            this.Projects = new ObservableListSource<Project>();
        }

        public int KeywordId { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Project> Projects { get; set; }
    }
}
