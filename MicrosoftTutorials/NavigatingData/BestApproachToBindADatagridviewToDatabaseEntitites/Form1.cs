using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestApproachToBindADatagridviewToDatabaseEntitites
{
    public partial class Form1 : Form
    {
        BindingList<ObjectToShow> _blstObjectToShow = new BindingList<ObjectToShow>();
        BindingSource _bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateBindings()
        {
            //if we don't put this, each public property in ObjectToshow will generate a new column
            //in the datagridview.
            //I think it's best to create the columns from the editor.
            //database -> <- bindingList -> <- bindingSource -> <- datagridview <- user

            _bindingSource.DataSource = _blstObjectToShow;
            dataGridView1.DataSource = _bindingSource;

            dataGridView1.Columns["Column_Data1"].DataPropertyName = "Data1";
            dataGridView1.Columns["Column_Data2"].DataPropertyName = "Data2";

        }
    }
}
