using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Console
{
    class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolDBContext>
    {
        protected override void Seed(SchoolDBContext context)
        {
            IList<Grade> grades = new List<Grade>();

            grades.Add(new Grade() { GradeName = "Grade1", Section = "A" });
            grades.Add(new Grade() { GradeName = "Grade1", Section = "B" });
            grades.Add(new Grade() { GradeName = "Grade1", Section = "C" });
            grades.Add(new Grade() { GradeName = "Grade2", Section = "A" });
            grades.Add(new Grade() { GradeName = "Grade3", Section = "A" });            

            base.Seed(context);
        }
    }
}
