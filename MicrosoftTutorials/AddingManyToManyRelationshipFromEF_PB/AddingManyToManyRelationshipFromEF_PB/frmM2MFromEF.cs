using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddingManyToManyRelationshipFromEF_PB
{
    public partial class frmM2MFromEF : Form
    {
        BindingSource _bsTerritories = new BindingSource();
        BindingSource _bsEmployees = new BindingSource();

        public frmM2MFromEF()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
