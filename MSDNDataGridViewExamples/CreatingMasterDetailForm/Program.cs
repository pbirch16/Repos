//https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/creating-a-master-detail-form-using-two-datagridviews
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingMasterDetailForm
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
            Application.Run(new frmDGVMDF());
        }
    }
}
