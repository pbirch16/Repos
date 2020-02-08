using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEF
{
    public partial class Form1 : Form
    {
        Model1Container ThisContainer;
        public Form1()
        {
            InitializeComponent();

            // Define a container to hold the database information.
            ThisContainer = new Model1Container();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            //Display the number of database records
            MessageBox.Show("There are" + ThisContainer.Customers.Count().ToString() + " Records.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create a new record
            Customer ThisCustomer = ThisContainer.Customers.Create();

            //Add some random data
            Random ThisValue = new Random(DateTime.Now.Millisecond);
            ThisCustomer.FirstName = ThisValue.Next().ToString();
            ThisCustomer.LastName = ThisValue.Next().ToString();
            ThisCustomer.AddressLine1 = ThisValue.Next().ToString();
            ThisCustomer.AddressLine2 = ThisValue.Next().ToString();
            ThisCustomer.City = ThisValue.Next().ToString();
            ThisCustomer.State_Province = ThisValue.Next().ToString();
            ThisCustomer.ZIP_Postal_Code = ThisValue.Next().ToString();
            ThisCustomer.Region_Country = ThisValue.Next().ToString();

            //Add a new record
            ThisContainer.Customers.Add(ThisCustomer);
            ThisContainer.SaveChanges();

            //Inform the user
            MessageBox.Show("Added " + ThisCustomer.CustomerId.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the first record
            Customer ThisCustomer = null;
            if (ThisContainer.Customers.Count() > 0)
            {
                ThisCustomer = ThisContainer.Customers.First();
            }
            else
            {
                //Display an error message if there are no records to delete
                MessageBox.Show("No Records to Delete");
                return;
            }
            
            //Delete it
            ThisContainer.Customers.Remove(ThisCustomer);
            ThisContainer.SaveChanges();

            //Inform the user
            MessageBox.Show("Deleted " + ThisCustomer.CustomerId.ToString());
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Save the database
            ThisContainer.SaveChanges();

            //End the program
            Close();
        }
    }
}
