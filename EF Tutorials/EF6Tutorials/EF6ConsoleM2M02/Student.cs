using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ConsoleM2M02
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

