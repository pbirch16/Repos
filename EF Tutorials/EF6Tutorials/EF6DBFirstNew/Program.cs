//https://www.entityframeworktutorial.net/entityframework6/create-entity-data-model.aspx
//Note: I have recreated the SchoolDB via SSMS.  The original file downloaded from GitHub was incorrect.
//However this project is using the original SchoolDB contained in EF6DBFirst02
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DBFirstNew
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolDBEntities())
            {
                ///CreateRecord();
                //UpdateRecord();
                //DeleteRecord();

                //LINQMethod();
                //LINQQuery();
                //QryOS();
                //EntityConnection();
                //NativeSQL();

                //FindExample();

                //EagerLoadingExampleQ();

                LazyLoading LL = new LazyLoading();
                LL.LLExample01();
                int studentId = LL.studentId;
                StudentAddress studentAddress = LL.studentAddress;
            }

            Console.WriteLine("Press a key");
            Console.ReadKey();

        }

        static void CreateRecord()
        {
            using (var context = new SchoolDBEntities())
            {
                var std = context.Students.First<Student>();

                context.Students.Add(std);
                context.SaveChanges();
                std.StudentName = "Bill Gates";
                context.SaveChanges();
            }

        }

        static void UpdateRecord()
        {
            using (var context = new SchoolDBEntities())
            {
                var std = context.Students.First<Student>();

                std.StudentName = "William Gates";
                context.SaveChanges();
            }
        }

        static void DeleteRecord()
        {
            using (var context = new SchoolDBEntities())
            {
                var std = context.Students.First<Student>();
                context.Students.Remove(std);

                context.SaveChanges();
            }
        }

        //Querying with LINQ-to-Entities
        //https://www.entityframeworktutorial.net/Querying-with-EDM.aspx

        static void LINQMethod()
        {
            using (var context = new SchoolDBEntities())
            {
                var query = context.Students
                        .Where(s => s.StudentName == "Steve")
                        .FirstOrDefault<Student>();
            }
        }

        static void LINQQuery()
        {
            using (var context = new SchoolDBEntities())
            {
                var query = from st in context.Students
                            where st.StudentName == "Steve"
                            select st;

                var student = query.FirstOrDefault<Student>();
            }
        }

        //Querying with Object Services and Entity SQL

        //This doesn't work
        //static void QryOS()
        //{
        //    string sqlString = "SELECT VALUE st FROM SchoolDBEntities.Students " +
        //                        "AS st WHERE st.StudenName == 'Steve'";

        //    IObjectContextAdapter ctx = new
        //     var objctx = (ctx as  new IObjectContextAdapter).ObjectContext;

        //    ObjectQuery<Student> student = objctx.CreateQuery<Student>(sqlString);
        //    Student newStudent = student.First<Student>();
        //}

        static void EntityConnection()
        {
            using (var con = new EntityConnection("name=SchoolDBEntities"))
            {
                con.Open();
                EntityCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT VALUE st FROM SchoolDBEntities.Students as st where st.StudentName='Steve'";
                Dictionary<int, string> dict = new Dictionary<int, string>();
                using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                {
                    while (rdr.Read())
                    {
                        int a = rdr.GetInt32(0);
                        var b = rdr.GetString(1);
                        dict.Add(a, b);
                    }
                }
            }

        }

        //This doesn't work
        //static void NativeSQL()
        //{
        //    using (var ctx=new SchoolDBEntities())
        //    {
        //        var studentName = ctx.Students.SqlQuery("Select StudentId from Student where StudentName='Steve'").FirstOrDefault<Student>();
        //    }
        //}

        //LINQ-to_Entities Query
        //https://www.entityframeworktutorial.net/querying-entity-graph-in-entity-framework.aspx

        static void FindExample()
        {
            using (var ctx = new SchoolDBEntities())
            {
                var student = ctx.Students.Find(3);
            }
        }

        static void EagerLoadingExampleQ()
        {
            using (var ctx = new SchoolDBEntities())
            {
                var stud1 = (from s in ctx.Students.Include("Standard")
                             where s.StudentName == "Steve"
                             select s).FirstOrDefault < Student>();
            }
        }
    }
}
