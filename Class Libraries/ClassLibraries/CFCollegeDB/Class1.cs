using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCollegeDB
{
    public class Class1
    {
        private const string _connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=E:\Visual Studio 2019\Databases\M2MCollege.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30";


        public string connectionString
        {
            get{ return _connectionString; }
        }
    }

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

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }


}
