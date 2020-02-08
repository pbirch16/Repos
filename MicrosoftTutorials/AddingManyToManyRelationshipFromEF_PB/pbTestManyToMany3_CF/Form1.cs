using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Database = E:\Visual Studio 2019\Databases\Projects01.mdf

namespace pbTestManyToMany3_CF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //InitDatabase();
            //SetupTestData setup = new SetupTestData();
            //DisplayDatabaseData();
        }

        private void InitDatabase()
        {
            using (var ctx = new ProjectContext())
            {
                var soln = new Solution
                {
                    Name = "SN1",
                    Location="SL1",               
                };

                ctx.Solutions.Add(soln);
                ctx.SaveChanges();
            }
            MessageBox.Show("DB Created");
        }

        private void DisplayDatabaseData()
        {
            DisplayDatabaseData dbd = new DisplayDatabaseData();
            List<ProjectStructure> lst= dbd.GetKeywordByProject(1);
            int i = 3;
        }

        
        
        
    }
}
