//How to: Navigate Data with the Windows Forms BindingNavigator Control
//https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-navigate-data-with-the-windows-forms-bindingnavigator-control

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsingBindignNavigator
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
            Application.Run(new frmNavigateData());
        }
    }
}
