//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Many2ManyExample01
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}