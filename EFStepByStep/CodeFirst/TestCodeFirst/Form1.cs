using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirstClasses;

namespace TestCodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Create a new purchase
            Purchase NewPurchase = new Purchase()
            {
                Amount = new Decimal(5.99),
                PurchaseDate = DateTime.Now
            };

            //Create a new customer and add the purchase
            Customer NewCustomer = new Customer()
            {
                CustomerName = "Josh Bailey"
            };

            //Create the context
            using (RewardsContext ctx = new RewardsContext())
            {
                ctx.Customers.Add(NewCustomer);
                ctx.Purchases.Add(NewPurchase);
                ctx.SaveChanges();

                MessageBox.Show("Record added");
            }

        }
    }
}

