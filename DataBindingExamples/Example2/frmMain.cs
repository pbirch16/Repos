using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Example2
{
	// Shows Master-Detail, Table-Mapping, Fill a Combobox
	public partial class frmMain : Form
    {
        private String ConnectionString;
        private DataViewManager dsView;
        private DataSet ds;

        public frmMain()
        {
            InitializeComponent();
			Init();
        }

        private void Init()
        {

			// Setup DB - Connection
			ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
						@"AttachDbFilename=E:\Visual Studio 2019\Databases\Northwnd.mdf;" +
						"Integrated Security=True;" +
						"Connect Timeout=30";

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

			// Databinding for the Grid's
			dgvOrders.DataSource = dsView;
			dgvOrders.DataMember = "Customers.RelCustOrd";

			dgvOrderDetails.DataSource = dsView;
			dgvOrderDetails.DataMember = "Customers.RelCustOrd.RelOrdDet";

			// Databinding for the Combo Box
			//
			// If you have two controls bound to the same datasource, 
			// and you do not want them to share the same position, 
			// then you must make sure that the BindingContext member 
			// of one control differs from the BindingContext member of 
			// the other control. If they have the same BindingContext,
			// they will share the same position in the datasource.
			//
			// If you add a ComboBox and a DataGrid to a form, the default
			// behavior is for the BindingContext member of each of the
			// two controls to be set to the Form's BindingContext. Thus,
			// the default behavior is for the DataGrid and ComboBox to share
			// the same BindingContext, and hence the selection in the ComboBox
			// is synchronized with the current row of the DataGrid. If you
			// do not want this behavior, you should create a new BindingContext
			// member for at least one of the controls.
			//
			// IF YOU UNCOMMENT THE FOLLOWING LINE THE SYNC WILL NO MORE WORK
			// cbCust.BindingContext = new BindingContext(); 
			cbCust.DataSource = dsView;
			cbCust.DisplayMember = "Customers.CompanyName";
			cbCust.ValueMember = "Customers.CustomerID";

			// Databinding for the Text Columns
			txtContact.DataBindings.Add("Text", dsView, "Customers.ContactName");
			txtPhoneNo.DataBindings.Add("Text", dsView, "Customers.Phone");
			txtFaxNo.DataBindings.Add("Text", dsView, "Customers.Fax");
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			if (this.BindingContext[dsView, "Customers"].Position > 0)
			{
				this.BindingContext[dsView, "Customers"].Position--;
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			CurrencyManager cm = (CurrencyManager)this.BindingContext[dsView, "Customers"];
			if (cm.Position < cm.Count - 1)
			{
				cm.Position++;
			}
		}
	}
}
