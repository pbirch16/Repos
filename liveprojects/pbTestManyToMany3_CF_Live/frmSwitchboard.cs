using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Database = E:\Visual Studio 2019\Databases\Projects.mdf
// Connection String in App.config:
// name="CSProjectsDB"
// "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Visual Studio 2019\Databases\Projects.mdf;
// Integrated Security=True;Connect Timeout=30"


namespace pbTestManyToMany3_CF_Live
{
    public partial class frmSwitchBoard : Form
    {
        public frmSwitchBoard()
        {
            InitializeComponent();
        }

        private void btnSetupTestdData_Click(object sender, EventArgs e)
        {
            SetupTestData std = new SetupTestData();
        }

        private void btnCreateDb_Click(object sender, EventArgs e)
        {
            InitDatabase initdb = new InitDatabase();
            btnCreateDb.Enabled = false;
        }

        private void btnDisplayDb_Click(object sender, EventArgs e)
        {
            DisplayDatabaseData ddd = new DisplayDatabaseData();
            ddd.Display();
        }

        private void btnClearDb_Click(object sender, EventArgs e)
        {
            DeleteAllData dad = new DeleteAllData();
            dad.ProcessDelete();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    dlgSolutionsAndProjects dlg = new dlgSolutionsAndProjects();
        //    dlg.ShowDialog();
        //}

        private void btnPandK_Click(object sender, EventArgs e)
        {
            dlgProjectsAndKeywords dlg = new dlgProjectsAndKeywords();
            dlg.Show();
        }

        private void btnProjectsKeywords_Click(object sender, EventArgs e)
        {
            dlgProjectsKeywords dlg = new dlgProjectsKeywords();
            dlg.Show();
        }

        private void btnMultiUpdate_Click(object sender, EventArgs e)
        {
            dlgMultiUpdates dlg = new dlgMultiUpdates();
            dlg.Show();
        }

        private void btnPKX_Click(object sender, EventArgs e)
        {
            dlgProjectsKeywordsXrefs dlg = new dlgProjectsKeywordsXrefs();
            dlg.Show();
        }
    }
}
