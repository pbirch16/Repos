//https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.controlbindingscollection?view=netframework-4.8
//https://support.microsoft.com/en-gb/help/314145/how-to-populate-a-dataset-object-from-a-database-by-using-visual-c-net
//https://www.akadia.com/services/dotnet_databinding.html

//The following code example adds Binding objects to a ControlBindingsCollection of five controls:
//four TextBox controls and a DateTimePicker control.
//The ControlBindingsCollection is accessed through the DataBindings property of the Control class.
using System;
using System.Windows.Forms;

namespace ControlBindingsCollection
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
