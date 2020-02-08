using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveThruDataset
{
    // This form demonstrates using a BindingNavigator to display
    // rows from a database query sequentially.
    public partial class frmMoveThruDataset : Form
    {
        BindingNavigator bnCustomers = new BindingNavigator(true);

        // This is the BindingSource that provides data for
        // the Textbox control.
        BindingSource bsCustomers = new BindingSource();

        // This is the TextBox control that displays the CompanyName
        // field from the DataSet.
        TextBox txtCompanyName = new TextBox();
        public frmMoveThruDataset()
        {
            InitializeComponent();

            // Set up the BindingSource component
            bnCustomers.BindingSource = bsCustomers;
            bnCustomers.Dock = DockStyle.Top;
            this.Controls.Add(bnCustomers);

            // Set up the TextBox control for displaying customer names.
            txtCompanyName.Dock = DockStyle.Bottom;
            this.Controls.Add(txtCompanyName);

            //Set the form size
            this.Size = new Size(800, 200);
        }

        private void frmMoveThruDataset_Load(object sender, EventArgs e)
        {
            string strConn = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename = E:\Visual Studio 2019\Databases\Rewards.mdf;" +
            @"Integrated Security = True; Connect Timeout = 30";

            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand("Select * From Customers", sqlConn);
                SqlDataAdapter da1 = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet("Customers");
                ds.Tables.Add("Customers");
                da1.Fill(ds.Tables["Customers"]);                       

                // Assign the DataSet as the DataSource for the BindingSource.
                bsCustomers.DataSource = ds.Tables["Customers"];

                // Bind the CompanyName field to the TextBox control.
                txtCompanyName.DataBindings.Add(new Binding("Text", bsCustomers, "CustomerName", true));
            }
        }
    }
}

