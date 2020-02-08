using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnboundDataGridViewControl
{
    public partial class frmUnboundDGV : Form
    {
        private DataGridView dgvSongs = new DataGridView();

        public frmUnboundDGV()
        {
            InitializeComponent();
        }

        private void SetupDGV()
        {
            this.Controls.Add(dgvSongs);

            dgvSongs.ColumnCount = 5;
            dgvSongs.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvSongs.ColumnHeadersDefaultCellStyle.Font = new Font(dgvSongs.Font, FontStyle.Bold);
            dgvSongs.Name = "dgvSongs";
            dgvSongs.Location = new Point(8, 8);
            dgvSongs.Size = new Size(500, 250);
            dgvSongs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvSongs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvSongs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvSongs.GridColor = Color.Black;
            dgvSongs.RowHeadersVisible = false;

            dgvSongs.Columns[0].Name = "Release Date";
            dgvSongs.Columns[1].Name = "Track";
            dgvSongs.Columns[2].Name = "Title";
            dgvSongs.Columns[3].Name = "Artist";
            dgvSongs.Columns[4].Name = "Album";
            dgvSongs.Columns[4].DefaultCellStyle.Font = new Font(dgvSongs.DefaultCellStyle.Font, FontStyle.Italic);

            dgvSongs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSongs.MultiSelect = false;
            dgvSongs.Dock = DockStyle.Fill;
            
            dgvSongs.CellFormatting += DgvSongs_CellFormatting;
        }



        private void PopulateDGV()
        {
            string[] row0 = { "22/11/1968", "29", "Revolution 9", "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "23/11/1960", "6", "Fools Rush In", "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days", "Pink Floyd", "Meddle" };
            string[] row3 = { "25/6/1988", "7", "Where Is My Mind?", "Pixies", "Surfer Rosa" };
            string[] row4 = { "13/5/1981", "9", "Can't Find My Mind", "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "10/6/2003", "13", "Scatterbrain. (As Dead As Leaves.)", "Radiohead", "Hail to the Thief" };
            string[] row6 = { "30/8/1992", "3", "Dress", "P J Harvey", "Dry" };

            dgvSongs.Rows.Add(row0);
            dgvSongs.Rows.Add(row1);
            dgvSongs.Rows.Add(row2);
            dgvSongs.Rows.Add(row3);
            dgvSongs.Rows.Add(row4);
            dgvSongs.Rows.Add(row5);
            dgvSongs.Rows.Add(row6);

            dgvSongs.Columns[0].DisplayIndex = 3;
            dgvSongs.Columns[1].DisplayIndex = 4;
            dgvSongs.Columns[2].DisplayIndex = 0;
            dgvSongs.Columns[3].DisplayIndex = 1;
            dgvSongs.Columns[4].DisplayIndex = 2;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dgvSongs.Rows.Add();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvSongs.SelectedRows.Count > 0 &&
                dgvSongs.SelectedRows[0].Index != dgvSongs.Rows.Count - 1)
            {
                dgvSongs.Rows.RemoveAt(dgvSongs.SelectedRows[0].Index);
            }
        }

        private void DgvSongs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.dgvSongs.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString()).ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            string msg = string.Format("{0} is not a valid date. ", e.Value.ToString());
                            MessageBox.Show(msg);
                        }

                    }
                }
            }
        }

        private void frmUnboundDGV_Load(object sender, EventArgs e)
        {
            SetupDGV();
            PopulateDGV();
        }
    }
}
