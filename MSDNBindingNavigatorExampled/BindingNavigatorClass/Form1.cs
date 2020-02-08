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

// This form demonstrates using a BindingNavigator to display 
// rows from a database query sequentially.

namespace BindingNavigatorClass
{
    public partial class Form1 : Form
    {
        // This is the BindingNavigator that allows the user
        // to navigate through the rows in a DataSet.
        BindingNavigator _customersBindingNavigator = new BindingNavigator(false);

        // This is the BindingSource that provides data for
        // the Textbox control.
        BindingSource _customersBindingSource = new BindingSource();

        // This is the TextBox control that displays the CompanyName
        // field from the DataSet.
        TextBox _companyNameTextBox = new TextBox();
        
        public Form1()
        {
            InitializeComponent();
            Init();
        }


        private void Init()
        {
            // Set up the BindingSource component.
            _customersBindingNavigator.AddStandardItems();
            _customersBindingNavigator.BindingSource = _customersBindingSource;
            _customersBindingNavigator.Dock = DockStyle.Top;
            this.Controls.Add(_customersBindingNavigator);

            // Set up the TextBox control for displaying company names.
            _companyNameTextBox.Dock = DockStyle.Bottom;
            this.Controls.Add(_companyNameTextBox);
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Open a connection to the database.
            // Replace the value of connectString with a valid 
            // connection string to a Northwind database accessible 
            // to your system.
            string connectString=
                        @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                        @"AttachDbFilename=E:\Visual Studio 2019\Databases\Northwnd.mdf;" +
                        "Integrated Security=True;" +
                        "Connect Timeout=30";

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                SqlDataAdapter dataAdapter1 =
                    new SqlDataAdapter(new SqlCommand("Select * From Customers", connection));
                DataSet ds = new DataSet("Northwind Customers");
                ds.Tables.Add("Customers");
                dataAdapter1.Fill(ds.Tables["Customers"]);

                // Assign the DataSet as the DataSource for the BindingSource.
                this._customersBindingSource.DataSource = ds.Tables["Customers"];

                // Bind the CompanyName field to the TextBox control.
                this._companyNameTextBox.DataBindings.Add(
                                                            new Binding("Text",
                                                            this._customersBindingSource,
                                                            "CompanyName",
                                                            true));
            }

        }
    }
}
