using System;
using System.Collections.Generic;

namespace Many2ManyExample01
{
    public class Course
    {
        //https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms
        private readonly ObservableListSource<Student> _courses = new ObservableListSource<Student>();
        public Course()
        {

            //this.Students = new HashSet<Student>();


        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ObservableListSource<Student> Students { get { return _courses; } }
    }
}