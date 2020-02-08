using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Windows.Forms;
using Rewards;
using System.Linq;
//using System.Data.Entity.Core.EntityClient;
//using System.Data.Entity.Core.Objects;

namespace TestCodeFirst
{
    public partial class frmTestCodeFirst : Form
    {
        public frmTestCodeFirst()
        {
            InitializeComponent();
        }

        //See Page 70 et seq (I have switched to the code-first database)
        //NB I have changed te entity names to Purchase and Customer, rather than the confusing plural versions
        //used in the model-first example
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Purchase p = new Purchase()
            {
                Amount = new Decimal(5.24),
                PurchaseDate = DateTime.Now
            };

            Customer c = new Customer()
            {
                CustomerName = "The Famous Eccles"
            };

            using (RewardsContext ctx = new RewardsContext())
            {
                ctx.Customers.Add(c);
                ctx.Purchases.Add(p);

                ctx.SaveChanges();

                MessageBox.Show("Record Added");

                //Rewards.RewardsContext
            }
        }


        //Page 86
        private void btnQuery_Click(object sender, EventArgs e)
        {

            EntityConnection con = new EntityConnection("name=Rewards.RewardsContext");
            ObjectContext octx = new ObjectContext(con);

            //Define a command string for making the query
            string EntitySQLCmd =
            "SELECT VALUE CustomerList " +
            "FROM RewardsContext.Customer " +
            "AS CustomerList";

            //Create a query object
            ObjectQuery<Customer> qry = new ObjectQuery<Customer>(EntitySQLCmd, octx);

            //Execute the query
            List<Customer> lstResult = qry.Execute(MergeOption.NoTracking).ToList();

            //Display the customer name
            MessageBox.Show(lstResult[0].CustomerName);

        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.rewardsDataSet);

        }

        private void frmTestCodeFirst_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rewardsDataSet.Purchases' table. You can move, or remove it, as needed.
            this.purchasesTableAdapter.Fill(this.rewardsDataSet.Purchases);
            // TODO: This line of code loads data into the 'rewardsDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.rewardsDataSet.Customers);

        }
    }
}
