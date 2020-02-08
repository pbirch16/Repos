//Page 30 Chapter 2
//Defining a basic query
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestBasicQuery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set |DataDirectory| value

            //var bd = AppDomain.CurrentDomain.BaseDirectory;
            //var dd = AppDomain.CurrentDomain.GetData("DataDirectory");
            //AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Uers\pbirc");
            //var ddnew = AppDomain.CurrentDomain.GetData("DataDirectory");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
