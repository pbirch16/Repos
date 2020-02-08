using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace pbTestManyToMany3_CF
{
    public partial class frmDbMaint : Form
    {
        private ProjectContext _ctx = new ProjectContext();

        public frmDbMaint()
        {
            InitializeComponent();
        }

        private void btnClearDatabase_Click(object sender, EventArgs e)
        {

        }

        private void ClearTheDatabase()
        {
            var qryProj =
                (from p in _ctx.Projects
                 select p).ToList();
            //_ctx.Projects.DeleteAllOnSubmit();

                var qryKW =
                    (from k in _ctx.Keywords
                     select k).ToList();
              //       _ctx.Keywords.del
              
        }

        private void btnUpdateProjects_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateSolutions_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateReferences_Click(object sender, EventArgs e)
        {
            
        }
    }
}
