// Database = E:\Visual Studio 2019\Databases\Projects.mdf
// Connection String in App.config:
// name="CSProjectsDB"
// "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Visual Studio 2019\Databases\Projects.mdf;
// Integrated Security=True;Connect Timeout=30"

using System.Windows.Forms;

namespace pbTestManyToMany3_CF_Live
{
    class InitDatabase
    {
        public InitDatabase()
        {
            using (var ctx = new ProjectContext())
            {
                var soln = new Solution
                {
                    Name = "SN1",
                    Location = "SL1",
                };

                ctx.Solutions.Add(soln);
                ctx.SaveChanges();
            }
            MessageBox.Show("Database Created");
        }
    }
}
