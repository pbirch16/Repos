using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ValidatingDataInDGV
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            // Initialize the form.
            this.dataGridView1.Dock = DockStyle.Fill;
            this.Controls.Add(dataGridView1);
        }

        private static DataTable GetData(string selectCommand)
        {
            string connectionString =
                        @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename=E:\Visual Studio 2019\Databases\Northwnd.mdf;" +
                        "Integrated Security=True;" +
                        "Connect Timeout=30";

            // Connect to the database and fill a data table.
            SqlDataAdapter adapter =
                new SqlDataAdapter(selectCommand, connectionString);
            DataTable data = new DataTable();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(data);

            return data;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Attach DataGridView events to the corresponding event handlers.
            dataGridView1.CellValidating += DataGridView1_CellValidating;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;

            // Initialize the BindingSource and bind the DataGridView to it.
            bindingSource1.DataSource = GetData("select * from Customers");
            this.dataGridView1.DataSource = bindingSource1;
            this.dataGridView1.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText =
        dataGridView1.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("CompanyName")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "Company Name must not be empty";
                e.Cancel = true;
            }
        }
    }
}
