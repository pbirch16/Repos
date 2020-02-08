using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEFModelFirst
{
    public partial class Form1 : Form
    {

        //Define a container to hold the database information
        Model1Container ThisContainer;
        public Form1()
        {
            InitializeComponent();

            ThisContainer = new Model1Container();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            //Display the number of database records
            MessageBox.Show("There are " + ThisContainer.Customers.Count().ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Customer ThisCustomer = ThisContainer.Customers.Create();

            //Create a new record
            Random ThisValue = new Random(DateTime.Now.Millisecond);
            
            //add some random data
            ThisCustomer.FirstName = ThisValue.Next().ToString();
            ThisCustomer.LastName = ThisValue.Next().ToString();
            ThisCustomer.AdressLine1 = ThisValue.Next().ToString();
            ThisCustomer.AddressLine2 = ThisValue.Next().ToString();
            ThisCustomer.City = ThisValue.Next().ToString();
            ThisCustomer.Region = ThisValue.Next().ToString();
            ThisCustomer.PostalCode = ThisValue.Next().ToString();

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

            if (ThisContainer.Customers.Count()>0)
            {
                ThisCustomer = ThisContainer.Customers.First();
            }
            else
            {
                //Display an error message if there are no records to delete
                MessageBox.Show("No records to delete");
                return;
            }

            //Delete it
            ThisContainer.Customers.Remove(ThisCustomer);
            ThisContainer.SaveChanges();

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
