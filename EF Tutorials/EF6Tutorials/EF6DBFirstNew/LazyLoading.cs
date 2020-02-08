using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DBFirstNew
{
    class LazyLoading
    {
        private int _studentID = 0;
        private StudentAddress _studentAddress = new StudentAddress();

        //public LazyLoading()
        //{

        //}


        public int studentId
        {
            get => _studentID;            
        }
        public StudentAddress studentAddress
        {
            get => _studentAddress;
        }
        public void LLExample01()
        {
            using (var ctx = new SchoolDBEntities())
            {
                //Loading students only
                List<Student> lstStudents = ctx.Students.ToList<Student>();
                Student std = lstStudents[0];
                _studentID = std.StudentID;

                //Loads student address for particular student only
                _studentAddress = std.StudentAddress;
            }
        }
    }
}
