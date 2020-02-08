namespace pbTestManyToMany3_CF
{
    public class Solution
    {
        public Solution()
        {            
            this.Projects = new ObservableListSource<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public virtual ObservableListSource<Project> Projects { get; set; }
    }
}
