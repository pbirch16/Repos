using System.ComponentModel.DataAnnotations;

namespace EFT_ConfigureManyToManyDefaultJT
{
    public class Student
    {
        public Student()
        {
            this.Courses = new ObservableListSource<Course>();
        }

        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }

        public virtual ObservableListSource<Course> Courses { get; set; }
    }
}
