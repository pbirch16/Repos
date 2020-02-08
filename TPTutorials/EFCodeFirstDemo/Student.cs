using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    public class Student
    {
        public int StudentId{get;set;}        
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrolmentDate { get; set; }

        public virtual ICollection<Enrolment> Enrolments { get; set; }
    }
}
