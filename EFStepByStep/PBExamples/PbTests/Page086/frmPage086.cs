
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rewards;

namespace Page086
{
    public partial class frmPage086 : Form
    {
    
        public frmPage086()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Purchase p = new Purchase()
            {
                Amount = new Decimal(89.547),
                PurchaseDate = DateTime.Parse("5/8/1956 15:26")
            };

            Customer c = new Customer()
            {
                CustomerName = "Fred Cringinnut",
            };

            using (RewardsContext ctx = new RewardsContext())
            {
                ctx.Customers.Add(c);
                ctx.Purchases.Add(p);
                ctx.SaveChanges();
                MessageBox.Show("Record added");
            }
        }


        //Page 86
        private void btnQuery_Click(object sender, EventArgs e)
        {
            using (RewardsContext ctx = new RewardsContext())
            {
            ObjectContext octx=
                //Define a command string for making the query
                string EntitySQLCmd =
                    "SELECT VALUE CustomerList " +
                    "FROM ctx.Customers " +
                    "AS CustomerList";

                //Create a query object
                ObjectQuery<Customer> Query = new ObjectQuery<Customer>(EntitySQLCmd, ctx);
            }
        }
    }
}
