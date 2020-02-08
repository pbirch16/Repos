//Walkthrough: Creating an Unbound Windows Forms DataGridView Control
//https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/walkthrough-creating-an-unbound-windows-forms-datagridview-control
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnboundDataGridViewControl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUnboundDGV());
        }
    }
}
