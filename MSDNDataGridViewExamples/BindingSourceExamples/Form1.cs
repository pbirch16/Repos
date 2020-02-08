//https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.bindingsource.list?view=netframework-4.8
//BindingSource.List Property
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

namespace BindingSourceExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create the connection string, data adapter and data table.
            SqlConnection connectionString =
                new SqlConnection
                    (@"Data Source=(LocalDB)\MSSQLLocalDB;" +
                    @"AttachDbFilename=E:\Visual Studio 2019\Databases\Northwnd.mdf;" +
                    "Integrated Security=True;" +
                    "Connect Timeout=30");

            SqlDataAdapter customersTableAdapter =
                new SqlDataAdapter("Select * from Customers", connectionString);
            DataTable customerTable = new DataTable();

            // Fill the adapter with the contents of the customer table.
            customersTableAdapter.Fill(customerTable);

            // Set data source for BindingSource1.
            bindingSource1.DataSource = customerTable;

            // Set the label text to the number of items in the collection before
            // an item is removed.
            label1.Text = "Starting count: " + bindingSource1.Count.ToString();

            // Access the List property and remove an item.
            bindingSource1.List.RemoveAt(4);

            // Remove an item directly from the BindingSource. 
            // This is equivalent to the previous line of code.
            bindingSource1.RemoveAt(4);

            // Show the new count.
            label2.Text = "Count after removal: " + bindingSource1.Count.ToString();
        }
    }
}
