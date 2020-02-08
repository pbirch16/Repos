using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFCollegeDB;

namespace TestCollegeCL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CFCollegeDB.Class1 cdb = new CFCollegeDB.Class1();
            string cn = cdb.connectionString;

        }
    }
}
