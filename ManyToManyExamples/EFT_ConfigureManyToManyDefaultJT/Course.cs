namespace EFT_ConfigureManyToManyDefaultJT
{
    public class Course
    {
        public Course()
        {
            this.Students = new ObservableListSource<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ObservableListSource<Student> Students { get; set; }
    }
}
