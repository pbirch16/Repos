﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDataApp
{
    public partial class frmNavigation : Form
    {
        public frmNavigation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the NewCustomer form as a dialog box,
        /// which returns focus to the calling form when it is closed. 
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewCustomer();
            frm.ShowDialog();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            Form frm = new frmFillOrCancel();
            frm.ShowDialog();
        }

        /// <summary>
        /// Closes the application (not just the Navigation form).
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
