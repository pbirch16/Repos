using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CustomizeItemAdditionWithTheWindowsFormsBindingSource
{
    // This form demonstrates using a BindingSource to provide
    // data from a collection of custom types to a DataGridView control.
    public partial class Form1 : Form
    {
        // This is the BindingSource that will provide data for
        // the DataGridView control.
        private BindingSource customersBindingSource = new BindingSource();

        // This is the DataGridView control that will display our data.
        private DataGridView customersDataGridView = new DataGridView();

        // Set up the StatusBar for displaying ListChanged events.
        private StatusBar status = new StatusBar();

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            
            // Set up the DataGridView control.
            this.customersDataGridView.Dock = DockStyle.Fill;
            customersDataGridView.AllowUserToAddRows = true;
            customersDataGridView.AllowUserToDeleteRows = true;
            //customersDataGridView.EditMode = EditOnKeystrokeOrF2;
            customersDataGridView.Enabled = true;
            this.Controls.Add(customersDataGridView);

            // Attach an event handler for the AddingNew event.
            this.customersBindingSource.AddingNew += CustomersBindingSource_AddingNew;


            // Attach an event handler for the ListChanged event.
            this.customersBindingSource.ListChanged += CustomersBindingSource_ListChanged;
        }

        // This event handler detects changes in the BindingSource 
        // list or changes to items within the list.
        private void CustomersBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            status.Text = e.ListChangedType.ToString();
        }

        // This event handler provides custom item-creation behavior.
        private void CustomersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = DemoCustomer.CreateNewCustomer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add a DemoCustomer to cause a row to be displayed.
            this.customersBindingSource.AddNew();

            // Bind the BindingSource to the DataGridView 
            // control's DataSource.
            this.customersDataGridView.DataSource = this.customersBindingSource;
        }
    }
}
