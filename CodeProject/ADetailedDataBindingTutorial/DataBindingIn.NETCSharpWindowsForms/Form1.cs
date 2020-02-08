//// Shows Master-Detail, Table-Mapping, Fill a Combobox
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBindingIn.NETCSharpWindowsForms
{
    public partial class Form1 : Form
    {
        private String ConnectionString;
        private DataViewManager dsView;
        private DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        public void MasterDetail()
        {
            

            // Setup DB-Connection
            ConnectionString = "data source=xeon;uid=sa;password=manager;database=northwind";
            SqlConnection cn = new SqlConnection(ConnectionString);

            // Create the DataSet
            ds = new DataSet("CustOrders");

            // Fill the Dataset with Customers, map Default Tablename
            // "Table" to "Customers".
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Customers", cn);
            da1.TableMappings.Add("Table", "Customers");
            da1.Fill(ds);

            // Fill the Dataset with Orders, map Default Tablename
            // "Table" to "Orders".
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Orders", cn);
            da2.TableMappings.Add("Table", "Orders");
            da2.Fill(ds);

            // Fill the Dataset with [Order Details], map Default Tablename
            // "Table" to "OrderDetails".
            SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM [Order Details]", cn);
            da3.TableMappings.Add("Table", "OrderDetails");
            da3.Fill(ds);

            // Show created Tablenames within the Dataset
            string myMessage = "Table Mappings: ";
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                myMessage += i.ToString() + " "
                    + ds.Tables[i].ToString() + " ";
            }

            // Establish the Relationship "RelCustOrd"
            // between Customers ---< Orders
            System.Data.DataRelation relCustOrd;
            System.Data.DataColumn colMaster1;
            System.Data.DataColumn colDetail1;
            colMaster1 = ds.Tables["Customers"].Columns["CustomerID"];
            colDetail1 = ds.Tables["Orders"].Columns["CustomerID"];
            relCustOrd = new System.Data.DataRelation("RelCustOrd", colMaster1, colDetail1);
            ds.Relations.Add(relCustOrd);

            // Establish the Relationship "RelOrdDet"
            // between Orders ---< [Order Details]
            System.Data.DataRelation relOrdDet;
            System.Data.DataColumn colMaster2;
            System.Data.DataColumn colDetail2;
            colMaster2 = ds.Tables["Orders"].Columns["OrderID"];
            colDetail2 = ds.Tables["OrderDetails"].Columns["OrderID"];
            relOrdDet = new System.Data.DataRelation("RelOrdDet", colMaster2, colDetail2);
            ds.Relations.Add(relOrdDet);

            // Show created Relations within the Dataset
            myMessage += "Relation Mappings: ";
            for (int i = 0; i < ds.Relations.Count; i++)
            {
                myMessage += i.ToString() + " "
                    + ds.Relations[i].ToString() + " ";
            }
            txtMessage.Text = myMessage;

            // The DataViewManager returned by the DefaultViewManager
            // property allows you to create custom settings for each
            // DataTable in the DataSet.
            dsView = ds.DefaultViewManager;

            // Grid Databinding
            grdOrders.DataSource = dsView;
            grdOrders.DataMember = "Customers.RelCustOrd";

            grdOrderDetails.DataSource = dsView;
            grdOrderDetails.DataMember = "Customers.RelCustOrd.RelOrdDet";

            // Combobox Databinding
            cbCust.DataSource = dsView;
            cbCust.DisplayMember = "Customers.CompanyName";
            cbCust.ValueMember = "Customers.CustomerID";

            // Text Columns Databinding
            txtContact.DataBindings.Add("Text", dsView, "Customers.ContactName");
            txtPhoneNo.DataBindings.Add("Text", dsView, "Customers.Phone");
            txtFaxNo.DataBindings.Add("Text", dsView, "Customers.Fax");
        }

        // Position to prev Record in Customer
        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            if (this.BindingContext[dsView, "Customers"].Position > 0)
            {
                this.BindingContext[dsView, "Customers"].Position--;
            }
        }

        // Position to next Record in Customer
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)this.BindingContext[dsView, "Customers"];
            if (cm.Position < cm.Count - 1)
            {
                cm.Position++;
            }
        }
    }
}
