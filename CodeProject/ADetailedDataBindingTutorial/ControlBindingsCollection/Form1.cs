using System;
using System.Data;
using System.Windows.Forms;
using LoadDatabase;

namespace ControlBindingsCollection
{
    public partial class Form1 : Form
    {                
        private DataSet _dataset;     

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDB ld = new LoadDB(_dataset, "Northwnd", "Customers");
            //ld.DisplayData();
            _dataset = ld.dataSet;

            BindControls();
        }

        protected void BindControls()
        {
            /* Create two Binding objects for the first two TextBox controls.
             * The data-bound property for both controls is the Text property.
             * The data source is a DataSet (ds).
             * The data member is the navigation path: TableName.ColumnName. */
            Binding b1 = new Binding("Text", _dataset, "customers.CompanyName");
            textBox1.DataBindings.Add(b1);
            Binding b2 = new Binding("Text", _dataset, "customers.CustomerID");
            textBox2.DataBindings.Add(b2);

            // Bind the DateTimePicker control by adding a new Binding. 
            // The data member of the DateTimePicker is a navigation path: TableName.RelationName.ColumnName.
            Binding b3 = new Binding("Value", _dataset, "customers.CustToOrders.OrderDate");
            dateTimePicker1.DataBindings.Add(b3);

            //Create a new Binding using the DataSet and a navigation path(TableName.RelationName.ColumnName).
            //Add event delegates for the Parse and Format events to the Binding object, and add the object to the
            //third TextBox control's BindingsCollection.
            //The delegates must be added before adding the Binding to the collection; otherwise, no formatting
            //occurs until the Current object of the BindingManagerBase for the data source changes.
            Binding b4 = new Binding("Text", _dataset, "customers.custToOrder Details.Quantity");
            b4.Parse += B4_Parse;
            b4.Format += B4_Format;
            textBox3.DataBindings.Add(b4);

            //Bind the fourth TextBox to the Value of the DateTimePicker control.
            //This demonstates how one control can be data-bound to another.
            textBox4.DataBindings.Add("Text", dateTimePicker1, "Value");

            // Get the BindingManagerBase for the textBox4 Binding.
            BindingManagerBase bmText = this.BindingContext
            [dateTimePicker1];

            // Print the Type of the BindingManagerBase, which is a PropertyManager because the data source
            //returns only a single property value.
            Console.WriteLine(bmText.GetType().ToString());

            // Print the count of managed objects, which is one.
            Console.WriteLine(bmText.Count);

            // Get the BindingManagerBase for the Customers table. 
            var bmCustomers = this.BindingContext[_dataset, "Customers"];

            // Print the Type and count of the BindingManagerBase.
            //Because the data source inherits from IBindingList,it is a RelatedCurrencyManager (a derived class of
            //CurrencyManager).
            Console.WriteLine(bmCustomers.GetType().ToString());
            Console.WriteLine(bmCustomers.Count);

            /* Get the BindingManagerBase for the Orders of the current
            customer using a navigation path: TableName.RelationName. */
            var bmOrders = this.BindingContext[_dataset, "customers.CustToOrders"];
        }

        private void B4_Format(object sender, ConvertEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void B4_Parse(object sender, ConvertEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SetupRelationships()
        {
            DataRelation CustToOrders;
            DataColumn colMaster1;
            DataColumn colDetail1;

            colMaster1 = _dataset.Tables["Customers"].Columns["CustomerID"];
        }
    }
}
