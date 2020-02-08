//How to: Move Through a DataSet with the Windows Forms BindingNavigator Control
//https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/move-through-a-dataset-with-wf-bindingnavigator-control
//Add load, save, and cancel buttons to the BindingNavigator component
//https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/load-save-and-cancel-bindingnavigator

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveThruDataset
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
            Application.Run(new frmMoveThruDataset());
        }
    }
}
