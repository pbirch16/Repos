//How to: Add Load, Save, and Cancel Buttons to the Windows Forms BindingNavigator Control
//https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/load-save-and-cancel-bindingnavigator
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddButtonsToBindingNavigator
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
            Application.Run(new frmAddButtons());
        }
    }
}
