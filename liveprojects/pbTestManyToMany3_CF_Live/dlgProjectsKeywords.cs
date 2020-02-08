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

namespace pbTestManyToMany3_CF_Live
{
    public partial class dlgProjectsKeywords : Form
    {
        ProjectContext _ctx;
        public dlgProjectsKeywords()
        {
            InitializeComponent();
            Init();
        }

        //================================================================================================================
        #region INIT
        private void Init()
        {
            _ctx = new ProjectContext();

            SetupProjectsDGV();
            SetupSolutionsDGV();
            SetupFullKeywordsDGV();
            SetupLinkedKeywordsDGV();
            SetupXrefsDGV();
            SetupLinkedXrefsDGV();

            //SetupProjectsBindingNavigator();                        
            //SetupFullKeywordsDataGridView();
            //SetupFullKeywordsBindingNavigator();
        }
        #endregion INIT
        //================================================================================================================
        #region PROJECTS NAVIGATOR

        #endregion PROJECTS NAVIGATOR
        //================================================================================================================
        #region KEYWORDS NAVIGATOR
        private void tsbRefreshDgvProjects_Click(object sender, EventArgs e)
        {
            //Refresh Projects from Database
            bsProjects.ResetBindings(false);
            //_bsrcProjectsKeywords.ResetBindings(false);
            bsLinkedKeywords.ResetBindings(false);

            dgvProjects.Columns[4].Visible = false;

            //Resize the DataGridView columns to fit the newly loaded data
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvProjects.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);  //The Solutions column is invisible.
        }
        #endregion KEYWORDS NAVIGATOR
        //================================================================================================================
        #region XREFS NAVIGATOR

        #endregion  XREFS NAVIGATOR
        //================================================================================================================
        #region PROJECTS DATA GRID VIEW
        private void SetupProjectsDGV()
        {
            //No need to select more than one row in this DGV    
            dgvProjects.MultiSelect = false;
            dgvProjects.AutoGenerateColumns = true;

            _ctx.Projects.Load();
            

            bsProjects.DataSource = _ctx.Projects.Local.ToBindingList();
            //dgvProjects.DataSource = bsProjects;
            //navProjects.BindingSource = bsProjects;
        }

        private void dgvProjects_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //These must be done after the DGV has finished initializing
            // Resize the DataGridView columns to fit the newly loaded data and hide the "Solution column"
            dgvProjects.Columns[4].Visible = false;
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvProjects.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            //See Projects\Notes3
            //http://stackoverflow.com/questions/3532680/i-want-to-programatically-generate-a-click-on-a-datagridview-row-in-c-sharp
            //Programatically generate a click on a DataGridView Row in C#   
            //Simulate a Cellclick with columnIndex = -1 and row Index = 0
            //This is happening before the dgv is filled from the bs?
            dgvProjects_CellClick(dgvProjects, new DataGridViewCellEventArgs(-1, 0));
        }

        private void dgvProjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (columnIndex != -1)
            {
                //Cell selected rather than whole row
                return;
            }

            if (rowIndex >= bsProjects.Count - 1)
            {
                //You have clicked beyond the last row containing data
                return;
            }

            DataGridViewRow row = dgvProjects.Rows[rowIndex];
            row.Selected = true;

            Project p = row.DataBoundItem as Project;

            //Use Navigation entity to get the bound Keywords and Xrefs
            bsLinkedKeywords.ResetBindings(false);
            bsLinkedKeywords.DataSource = p.Keywords.ToBindingList();

            bsLinkedXrefs.ResetBindings(false);
            bsLinkedXrefs.DataSource = p.Xrefs.ToBindingList();
        }


        #endregion PROJECTS DATA GRID VIEW
        //================================================================================================================
        #region SOLUTIONS DATA GRID VIEW
        private void SetupSolutionsDGV()
        {
            //No need to select more than one row in this DGV    
            dgvSolutions.MultiSelect = false;
            dgvSolutions.AutoGenerateColumns = true;

            _ctx.Solutions.Load();

            bsSolutions.DataSource = _ctx.Solutions.Local.ToBindingList();            
            
        }
        #endregion SOLUTIONS DATA GRID VIEW
        //================================================================================================================
        #region FULL KEYWORDS DATA GRID VIEW
        private void SetupFullKeywordsDGV()
        {
            dgvFullKeywords.AutoGenerateColumns = true;
            bsKeywords.DataSource = _ctx.Keywords.ToList();

            dgvFullKeywords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvFullKeywords.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //Allow user to select mutiple keywords for linking to a Project
            dgvFullKeywords.MultiSelect = true;
        }

        #endregion FULL KEYWORDS DATA GRID VIEW
        //================================================================================================================
        #region LINKED KEYWORDS DATA GRID VIEW
        private void SetupLinkedKeywordsDGV()
        {
            dgvLinkedKeywords.AutoGenerateColumns = true;
        }


        //private void FillBoundKeywordsSource(List<Keyword> lstKeywords)
        //{
        //    int ProjectId;

        //    List<int> lstKwIds = new List<int>();

        //    DataGridViewSelectedRowCollection rows = dgvProjects.SelectedRows;

        //    if (rows.Count == 0)
        //    {
        //        MessageBox.Show("No rows selected in the Projects DataGridView");
        //        return;
        //    }
        //    else if (rows.Count > 1)
        //    {
        //        MessageBox.Show("More than one row selected in the Projects DataGridView");
        //        return;
        //    }

        //    Project proj = rows[0].DataBoundItem as Project;
        //    ProjectId = proj.ProjectId;

        //    bsBoundKeywords.DataSource = proj.Keywords.ToBindingList();
        //    bsBoundKeywords.ResetBindings(false);
        //    dgvBoundKeywords.Refresh();            
        //}

        #endregion LINKED KEYWORDS DATA GRID VIEW
        //================================================================================================================
        #region XREFS DATA GRID VIEW

        private void SetupXrefsDGV()
        {
            //No need to select more than one row in this DGV    

            dgvXrefs.AutoGenerateColumns = true;
            bsXrefs.DataSource = _ctx.Xrefs.Local.ToBindingList();

            dgvXrefs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvXrefs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            //Allow user to select mutiple xrefs for linking to a Project
            dgvXrefs.MultiSelect = true;
        }

        private void dgvXrefs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }



        #endregion XREFS DATA GRID VIEW
        //================================================================================================================
        #region LINKED KEYWORDS DATA GRID VIEW
        private void SetupLinkedXrefsDGV()
        {
            dgvLinkedXrefs.AutoGenerateColumns = true;
        }
        #endregion LINKED KEYWORDS DATA GRID VIEW
        //================================================================================================================
        #region BUTTONS
        #region Keywords
        private void btnLinkKeywords_Click(object sender, EventArgs e)
        {
            //Add new project/Keyword pair(s) to the ProjectsKeyword source
            int ProjectId;

            //Get the selected row in the Projects DGV
            DataGridViewSelectedRowCollection projectRows = dgvProjects.SelectedRows;

            if (projectRows.Count == 0)
            {
                MessageBox.Show("No rows selected in the Projects DataGridView");
                return;
            }

            Project proj = projectRows[0].DataBoundItem as Project;
            ProjectId = proj.ProjectId;

            //Get the selected row(s) in the FullKeywords DGV
            DataGridViewSelectedRowCollection keywordRows = dgvFullKeywords.SelectedRows;

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

            //Add the links 
            foreach (Keyword keyword in lstKeywords)
            {
                proj.Keywords.Add(keyword);
                _ctx.SaveChanges();
            }
        }
        //private void btnLinkBoundKeywords_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnLinkBoundKeywords_Click(object sender, EventArgs e)
        //{
        //    //Add new project/Keyword pair(s) to the ProjectsKeyword source
        //    int ProjectId;

        //    //Get the selected row in the Projects DGV
        //    DataGridViewSelectedRowCollection projectRows = dgvProjects.SelectedRows;

        //    if (projectRows.Count == 0)
        //    {
        //        MessageBox.Show("No rows selected in the Projects DataGridView");
        //        return;
        //    }

        //    Project proj = projectRows[0].DataBoundItem as Project;
        //    ProjectId = proj.ProjectId;

        //    //Get the selected row(s) in the FullKeywords DGV
        //    DataGridViewSelectedRowCollection keywordRows = dgvFullKeywords.SelectedRows;

        //    if (keywordRows.Count == 0)
        //    {
        //        MessageBox.Show("No rows selected in the FullKeywords DataGridView");
        //        return;
        //    }

        //    List<Keyword> lstKeywords = new List<Keyword>();
        //    foreach (DataGridViewRow row in keywordRows)
        //    {
        //        Keyword kword = row.DataBoundItem as Keyword;
        //        lstKeywords.Add(kword);
        //    }

        //    //Add the links 
        //    foreach (Keyword keyword in lstKeywords)
        //    {
        //        proj.Keywords.Add(keyword);
        //        _ctx.SaveChanges();
        //    }        //}

        private void btnUnlinkKeywords_Click(object sender, EventArgs e)
        {
            throw new ArgumentException("btnUnlinkKeywords not implemented");
        }

        private void btnSubmitKeywords_Click(object sender, EventArgs e)
        {
            try
            {
                _ctx.SaveChanges();
                MessageBox.Show("Changes written to the Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void btnSubmit_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _ctx.SaveChanges();
        //        MessageBox.Show("Changes written to the Database");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        #endregion Keywords

        #region Xrefs
        private void btnLinkXrefs_Click(object sender, EventArgs e)
        {
            //Add new project/Xref pair(s) to the ProjectsKeyword source
            int ProjectId;

            //Get the selected row in the Projects DGV
            DataGridViewSelectedRowCollection projectRows = dgvProjects.SelectedRows;

            if (projectRows.Count == 0)
            {
                MessageBox.Show("No rows selected in the Projects DataGridView");
                return;
            }

            Project proj = projectRows[0].DataBoundItem as Project;
            ProjectId = proj.ProjectId;

            //Get the selected row(s) in the Xrefs DGV
            DataGridViewSelectedRowCollection xrefRows = dgvXrefs.SelectedRows;

            if (xrefRows.Count == 0)
            {
                MessageBox.Show("No rows selected in the Xrefs DataGridView");
                return;
            }

            List<Xref> lstXrefs = new List<Xref>();
            foreach (DataGridViewRow row in xrefRows)
            {
                Xref xref = row.DataBoundItem as Xref;
                lstXrefs.Add(xref);
            }

            //Add the links 
            foreach (Xref xref in lstXrefs)
            {
                proj.Xrefs.Add(xref);

                _ctx.SaveChanges();
            }
        }

        private void btnUnlinkXrefs_Click(object sender, EventArgs e)
        {
            throw new ArgumentException("btnUnlinkXrefs not implemented");
        }

        private void btnSubmitXrefs_Click(object sender, EventArgs e)
        {
            try
            {
                _ctx.SaveChanges();
                MessageBox.Show("Changes written to the Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Xrefs
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        #endregion BUTTONS
        //================================================================================================================
        #region NAVIGATOR TOOLSTRIP BUTTONS

        private void tsbSaveProjects_Click(object sender, EventArgs e)
        {
            _ctx.SaveChanges();
        }
        private void tsbSolutions_Click(object sender, EventArgs e)
        {
            _ctx.SaveChanges();
        }
        #endregion NAVIGATOR TOOLSTRIP BUTTONS
        //================================================================================================================
        #region MyRegion

        #endregion
        //================================================================================================================
        #region MISCELLANEOUS
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._ctx.Dispose();
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.bindingsource.list?view=netframework-4.8
        private void DisplayBindingsourceContents(BindingSource bs)
        {
            int count = bs.Count;
            foreach (var item in bs.List)
            {
                var v = item;
            }
        }

        private void tsbSaveSolutions_Click(object sender, EventArgs e)
        {

        }
        #endregion MISCELLANEOUS
        //================================================================================================================






    }
}
