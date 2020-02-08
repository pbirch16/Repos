//https://www.tutorialsteacher.com/linq/why-linq
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples01
{
    class Program
    {
        static Student[] m_studentArray =
        {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 },
                new Student() { StudentID = 2, StudentName = "Steve", Age = 21 },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 31 },
                new Student() { StudentID = 6, StudentName = "Chris", Age = 17 },
                new Student() { StudentID = 7, StudentName = "Rob", Age = 19 },
            };

        static List<string> m_courseList = new List<string>()
        {
                "C# Tutorials",
                "VB.NET Tutorials",
                "Learn C++",
                "MVC Tutorials",
                "Java"
            };

        static List<Student> m_studentList = new List<Student>()
        {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 },
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 },
                new Student() { StudentID = 6, StudentName = "Chris", Age = 17 },
                new Student() { StudentID = 7, StudentName = "Rob", Age = 19 }
            };


        static Student[] m_students;

        static void Main(string[] args)
        {
            //useForLoop();
            //useDelegate();
            //useLINQ();
            //LINQQuerySyntax01();
            //LINQQuerySyntax02();
            //LINQMethodSyntax01();
            //LINQMethodSyntax02();
            
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }

        static void useForLoop()
        {
            m_students = new Student[10];

            int i = 0;
            foreach (Student std in m_studentArray)
            {
                if (std.Age > 12 && std.Age < 20)
                {
                    m_students[i++] = std;
                }
            }
        }

        static void useDelegate()
        {
            m_students = StudentExtension.where(m_studentArray, delegate (Student std)
            {
                return std.Age > 12 && std.Age < 20;
            });
        }

        static void useLINQ()
        {
            // Use LINQ to find teenage students
            Student[] teenageStudents = m_studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();

            // Use LINQ to find first student whose name is Bill
            Student bill = m_studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();

            // Use LINQ to find student whose StudentID is 5
            Student student5 = m_studentArray.Where(s => s.StudentID == 5).FirstOrDefault();
        }

        static void LINQQuerySyntax01()
        {

            //LINQ Query Syntax
            var result = from s in m_courseList
                         where s.Contains("Tutorials")
                         select s;

            Console.WriteLine("List:");
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }

        static void LINQQuerySyntax02()
        {
            var teenageStudent = from s in m_studentList
                                 where s.Age > 12 && s.Age < 20
                                 select s;

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenageStudent)
            {
                Console.WriteLine(std.StudentName);
            }
        }

        static void LINQMethodSyntax01()
        {
            var result = m_courseList.Where(s => s.Contains("Tutorials"));

            Console.WriteLine("Courses:");

            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }

        static void LINQMethodSyntax02()
        {
            var teenageStudents = m_studentList.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();

            foreach (Student stu in teenageStudents)
            {
                Console.WriteLine(stu.StudentName);
            }
        }
    }
}
