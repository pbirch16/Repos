//EF Step by Step
//Page 57 Chapter 3
//Creating a code-first example (TestCodeFist and CodeFirstClasses)
//This program uses the name of the Connection String ("RewardCS") contained in the App.config file.  This is specified in the Context constructor.
//If the database already exists, it does not attempt to overwrite it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCodeFirst
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
