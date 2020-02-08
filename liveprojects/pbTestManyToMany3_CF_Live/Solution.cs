namespace pbTestManyToMany3_CF_Live
{
    public class Solution
    {
        public Solution()
        {
            this.Projects = new ObservableListSource<Project>();
        }

        public int SolutionId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ObservableListSource<Project> Projects { get; set; }
    }
}
