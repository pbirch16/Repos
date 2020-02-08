//How to: Customize Item Addition with the Windows Forms BindingSource
//https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-customize-item-addition-with-the-windows-forms-bindingsource?view=netframework-4.8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomizeItemAdditionWithTheWindowsFormsBindingSource
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
            Application.Run(new Form1());
        }
    }
}
