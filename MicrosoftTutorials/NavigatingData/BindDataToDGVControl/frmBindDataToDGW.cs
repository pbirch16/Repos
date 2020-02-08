using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindDataToDGVControl
{

    public partial class frmBindDataToDGW : Form
    {
        private DataGridView dgv1 = new DataGridView();
        private BindingSource bs1 = new BindingSource();
        private SqlDataAdapter da1 = new SqlDataAdapter();

        public frmBindDataToDGW()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            dgv1.Dock = DockStyle.Fill;
            Controls.Add(dgv1);
        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string.  
                // Replace <SQL Server> with the SQL Server for your Northwind sample database.
                // Replace "Integrated Security=True" with user login information if necessary.
                String connectionString =
                    @"Data Source = (LocalDB)\MSSQLLocalDB;" +
                    @"AttachDbFilename = C:\Users\pbirc\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\northwnd.mdf;" +
                    " Integrated Security = True; Connect Timeout = 30";

                // Create a new data adapter based on the specified query.
                SqlDataAdapter da1 = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da1);

                // Populate a new data table and bind it to the BindingSource.
                DataTable dt1 = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                da1.Fill(dt1);
                bs1.DataSource = dt1;

                // Resize the DataGridView columns to fit the newly loaded content.
                dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
            }

        }

        private void frmBindDataToDGW_Load(object sender, EventArgs e)
        {
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dgv1.DataSource = bs1;
            GetData("select * from Customers");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            // Reload the data from the database.
            GetData(da1.SelectCommand.CommandText);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Update the database with changes.
            SqlCommandBuilder bldr = new SqlCommandBuilder(da1);
            da1.SelectCommand = bldr.GetUpdateCommand();
            da1.Update((DataTable)bs1.DataSource);
        }
    }
}
