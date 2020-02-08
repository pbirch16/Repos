using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFCollegeDB;

namespace AddingManyToManyRelationshipFromEF_PB_CF_CollegeDB
{
    public partial class Form1 : Form
    {
        BindingSource bsCourses = new BindingSource();
        BindingSource bsStudents = new BindingSource();
        M2MCollegeContext ctx = new M2MCollegeContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctx.Students.Load();
            bsStudents.DataSource = ctx.Students.Local.ToBindingList();

            ctx.Courses.Load();
            bsCourses.DataSource = ctx.Courses.Local.ToBindingList();

            dgvStudents.DataSource = bsStudents;
            

            dgvCourses.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn dgvCoursesCmb = new DataGridViewTextBoxColumn();
            dgvCoursesCmb.DataPropertyName = "CourseId";
            dgvCourses.Columns.Add(dgvCoursesCmb);

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "Course Name";
            dgvCourses.Columns.Add(col1);

            dgvCourses.DataSource = bsCourses;
            //dgvCourses.DataMember = "Courses";

        }

        private void InitDatabase()
        {
            using (var ctx = new M2MCollegeContext())
            {
                //var course = new Course()
                //{
                //    CourseName = "Course1"
                //};

                //ctx.Courses.Add(course);

                var student = new Student()
                {
                    StudentName = "Peter"
                };

                ctx.Students.Add(student);

                ctx.SaveChanges();

                MessageBox.Show("DB Created?");

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            bsStudents.EndEdit();
            ctx.SaveChanges();
            //ctx.Dispose();
        }
    }
}

