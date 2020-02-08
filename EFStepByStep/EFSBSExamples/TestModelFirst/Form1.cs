using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestModelFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create a new purchase
            Purchase newPurchase = new Purchase();
            newPurchase.Amount = new decimal(5.87);
            newPurchase.PurchaseDate = DateTime.Now;

            Customer newCustomer = new Customer
            {
                CustomerName = "Peter Birch"
            };

            
        }
    }
}
