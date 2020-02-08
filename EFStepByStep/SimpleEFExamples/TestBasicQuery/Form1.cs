using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBasicQuery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Set |DataDirectory| value
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Uers\pbirc");
        }
    }
}
