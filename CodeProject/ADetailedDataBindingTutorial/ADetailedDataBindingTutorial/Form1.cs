using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ADetailedDataBindingTutorial
{
    public partial class Form1 : Form
    {
        BindingSource bsA = new BindingSource();    //Airplanes
        BindingSource bsP = new BindingSource();        //Passengers
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Airplane a1, a2, a3;

            bsA.Add(a1 = new Airplane("Boeing 747", 800));
            bsA.Add(a2 = new Airplane("Airbus A380", 1023));
            bsA.Add(a3 = new Airplane("Cessna 162", 67));
            a1.Passengers.Add(new Passenger("John Smith"));
            a1.Passengers.Add(new Passenger("Jack B. Nimble"));
            a1.Passengers.Add(new Passenger("Jib Jab"));
            a2.Passengers.Add(new Passenger("Jackie Tyler"));
            a2.Passengers.Add(new Passenger("Jane Doe"));
            a3.Passengers.Add(new Passenger("John Smith"));

            // Set up data binding for the parent Airplanes
            grid.DataSource = bsA;
            grid.AutoGenerateColumns = true;
            txtModel.DataBindings.Add("Text", bsA, "Model");

            // Set up data binding for the child Passengers
            bsP.DataSource = bsA;   //Connect the two sources
            bsP.DataMember = "Passengers";

            lstPassengers.DataSource = bsP;
            lstPassengers.DisplayMember = "Name";

            txtName.DataBindings.Add("Text", bsP, "Name");
            
            // Allow the user to add rows
            ((BindingList<Airplane>)bsA.List).AllowNew = true;
            ((BindingList<Airplane>)bsA.List).AllowRemove = true;

        }

        //private void l(object sender, DataGridViewCellPaintingEventArgs e)
        //{

        //}

        private void bsP_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
            {
                txtName.Enabled = bsP.Current != null;
            }
        }
    }
}
