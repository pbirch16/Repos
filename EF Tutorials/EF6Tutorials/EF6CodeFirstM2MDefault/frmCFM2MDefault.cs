using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF6CodeFirstM2MDefault
{
    public partial class frmCFM2MDefault : Form
    {
        public frmCFM2MDefault()
        {
            InitializeComponent();
        }

        private void frmCFM2MDefault_Load(object sender, EventArgs e)
        {
            //using (var ctx = new M2MCollegeContext())
            //{
            //    //var course = new Course()
            //    //{
            //    //    CourseName = "Course1"
            //    //};

            //    //ctx.Courses.Add(course);

            //    var student = new Student()
            //    {
            //        StudentName = "Peter"
            //    };

            //    ctx.Students.Add(student);

            //    ctx.SaveChanges();

            //    MessageBox.Show("DB Created?");
            //}

            //var student = new Student()
            //{
            //    StudentName = "Student2"
            //};

            //var course = new Course()
            //{
            //    CourseName="Course1"
            //};

            //Create(student, course);

            //InsertWithData(1, 2);
            //DeleteRelationship(1, 1);
            SetupTestData();

            MessageBox.Show("Completed");


        }

        private void SetupTestData()
        {
            using (M2MCollegeContext ctx = new M2MCollegeContext())
            {
                for (int i = 3; i < 8; i++)
                {
                    string studentName = "Student" + i.ToString();
                    string courseName = "Course" + i.ToString();

                    var student = new Student { StudentName = studentName };
                    var course = new Course { CourseName = courseName };
                    Create(student, course);
                }
            }
        }

        //CRUD + Link Existing-Records Operations

        //CREATE
        //https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
        //Insert
        private void Create(Student student, Course course)
        {
            using (var ctx = new M2MCollegeContext())
            {
                //Add instances to context
                ctx.Students.Add(student);
                ctx.Courses.Add(course);

                //Add instance to navigation property
                student.Courses.Add(course);

                ctx.SaveChanges();
            }

        }

        //LINK 
        private void InsertWithData(int studentId, int courseId)
        {
            /*
                * These steps apply to both entities
                * 
                * 1 - create instance of entity with relative primary key
                * 
                * 2 - add instance to context
                * 
                * 3 - attach instance to context
                */
            using (var ctx = new M2MCollegeContext())
            {
                //1
                Student s = new Student
                {
                    StudentId = studentId
                };

                //2
                ctx.Students.Add(s);

                //3
                ctx.Students.Attach(s);

                //1
                Course c = new Course { CourseId = courseId };

                //2
                ctx.Courses.Add(c);

                //3
                ctx.Courses.Attach(c);

                //Add instance to navigation property
                s.Courses.Add(c);

                ctx.SaveChanges();
            }

        }

        //UPDATE
        private void Update()
        {

        }

        //DELETE RELATIONSHIP
        //To delete relationship, instead of call Remove from context, we need to call it from
        //navigation property.
        private void DeleteRelationship(int studentId, int courseId)
        {
            using (M2MCollegeContext ctx = new M2MCollegeContext())
            {
                // Return one instance of each entity by primary key
                var student = ctx.Students.FirstOrDefault(s => s.StudentId == studentId);
                var course = ctx.Courses.FirstOrDefault(c => c.CourseId == courseId);

                // Call Remove method from navigation property for any instance
                // course.Students.Remove(student) also works
                student.Courses.Remove(course);

                ctx.SaveChanges();
            }
        }
    }

}
