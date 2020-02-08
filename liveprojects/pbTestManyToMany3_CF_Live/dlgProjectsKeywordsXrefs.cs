using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace pbTestManyToMany3_CF_Live
{
    public partial class dlgProjectsKeywordsXrefs : Form
    {
        ProjectContext _ctx;
        public dlgProjectsKeywordsXrefs()
        {
            InitializeComponent();
            navTest();
        }

        #region INIT
        private void dlgProjectsKeywordsXrefs_Load(object sender, EventArgs e)
        {
            _ctx = new ProjectContext();
            _ctx.Projects.Load();
            this.projectsBindingSource.DataSource = _ctx.Projects.Local.ToBindingList();

            _ctx.Keywords.Load();
            keywordBindingSource.DataSource = _ctx.Keywords.Local.ToBindingList();

            _ctx.Xrefs.Load();
            xrefBindingSource.DataSource = _ctx.Xrefs.Local.ToBindingList();
        }
        #endregion INIT

        #region SOLUTIONS

        #endregion SOLUTIONS

        #region PROJECTS
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("projectsBindingNavigator Add new item button clicked");
        }
        private void tsbProjectsSave_Click(object sender, EventArgs e)
        {

        }
        private void projectsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (columnIndex != -1)
            {
                //Cell selected rather than whole row
                return;
            }

            if (rowIndex >= projectsBindingSource.Count - 1)
            {
                //You have clicked beyond the last row containing data
                return;
            }

            DataGridViewRow row = projectsDataGridView.Rows[rowIndex];
            row.Selected = true;

            List<Keyword> lstKeywords = new List<Keyword>();

            int ProjectID = (row.DataBoundItem as Project).ProjectId;

            //FillBoundKeywordsSource();
        }

        private void navTest()
        {
            projectsBindingNavigator.AddStandardItems();            
            foreach (var item in projectsBindingNavigator.Items)
            {
                string s = item.ToString();
                var t = item.GetType();
            }
        }

        #endregion PROJECTS

        #region KEYWORDS
        private void tsbSaveKeywords_Click(object sender, EventArgs e)
        {
            this.Validate();

            //List<Keyword> lstKeywords = _ctx.Keywords.Local.ToList();

            //foreach (Keyword k in lstKeywords)
            //{
            //    if (k.Projects == null)
            //    {
            //        _ctx.Keywords.Remove(k);
            //    }
            //}

            _ctx.SaveChanges();

            allKeywordsDataGridView.Refresh();

        }
        #endregion KEYWORDS
        //E:\Visual Studio 2013\Projects\MSDN Examples\Database Examples\pbTestManyToMany3\        
        //https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
        private void btnLinkKeywords_Click(object sender, EventArgs e)
        {
            //int projectId;            

            //Get the selected row in the Projects DGV
            DataGridViewSelectedRowCollection projectRows = projectsDataGridView.SelectedRows;

            if (projectRows.Count == 0)
            {
                MessageBox.Show("No rows selected in the Projects DataGridView");
                return;
            }
            else if (projectRows.Count > 1)
            {
                MessageBox.Show("More than one row selected in the Projects DataGridView");
                return;
            }

            Project proj = projectRows[0].DataBoundItem as Project;
            //projectId = proj.ProjectId;

            //Get the selected row(s) in the FullKeywords DGV
            DataGridViewSelectedRowCollection keywordRows = allKeywordsDataGridView.SelectedRows;

            if (keywordRows.Count == 0)
            {
                MessageBox.Show("No rows selected in the FullKeywords DataGridView");
                return;
            }

            List<Keyword> lstKeywords = new List<Keyword>();
            foreach (DataGridViewRow row in keywordRows)
            {
                Keyword kword = row.DataBoundItem as Keyword;
                lstKeywords.Add(kword);
            }

            foreach (Keyword kw in lstKeywords)
            {
                //Set the navigation property of each of the selected Keyword(s) to link it(them)
                //to the selected Project
                kw.Projects.Add(proj);
            }

            //Write the changes to the database
            _ctx.SaveChanges();

            //Simulate a click on the current row
            //int currentRow = projectRows[0].Index;
            //_dgvProjects_CellClick(_dgvProjects, new DataGridViewCellEventArgs(-1, currentRow));
        }

        #region XREFS
        private void tsbSaveXrefs_Click(object sender, EventArgs e)
        {
            this.Validate();

            //List<Xref> lstXrefs = _ctx.Xrefs.Local.ToList();

            //foreach (Xref x in lstXrefs)
            //{
            //    if (x.Projects == null)
            //    {
            //        _ctx.Xrefs.Remove(x);
            //    }
            //}

            _ctx.SaveChanges();

            linkedXrefsDataGridView.Refresh();
        }
        #endregion XREFS


        #region ENDING
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._ctx.Dispose();
        }

        private void bindingNavigatorAddNewItem2_Click(object sender, EventArgs e)
        {
            int i = 2;
        }
        #endregion ENDING


        //protected override void OnClick(EventArgs e)
        //{
        //    base.OnClick(e);
        //}

        //private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        //{

        //}

        //private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        //{

        //}
    }
}
