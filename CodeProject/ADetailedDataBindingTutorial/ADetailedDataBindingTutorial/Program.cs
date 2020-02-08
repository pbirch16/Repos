//A Detailed Data Binding Tutorial
//E:\Visual Studio 2019\Books\Code Project\BindingTest\BindingTest
//https://www.codeproject.com/Articles/24656/A-Detailed-Data-Binding-Tutorial
using System;
using System.Windows.Forms;

namespace ADetailedDataBindingTutorial
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
