using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6Console01
{
[Table("StudentMaster", Schema ="Admin")]    //04
public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        //public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public Grade Grade { get; set; }
    }
}
