//https://www.tutorialspoint.com/entity_framework/entity_framework_code_first_approach.htm
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main()
        {

            using (var context = new MyContext())
            {
                //Create and save a Student
                Console.WriteLine("Adding new students");

                var student = new Student
                {
                    FirstMidName = "Alain",
                    LastName = "Bomer",
                    EnrolmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.Students.Add(student);

                var student1 = new Student
                {
                    FirstMidName = "Mark",
                    LastName = "Upston",
                    EnrolmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.Students.Add(student1);
                context.SaveChanges();

                // Display all Students from the database
                var students = (from s in context.Students
                                orderby s.FirstMidName
                                select s).ToList<Student>();


                foreach (var stdnt in students)
                {
                    string name = stdnt.FirstMidName + " " + stdnt.LastName;
                    Console.WriteLine("StudentId: {0}, Name: {1}", stdnt.StudentId, name);
                }
                Console.WriteLine("Press a key to exit");
                Console.ReadKey();
            }
        }
    }
}

