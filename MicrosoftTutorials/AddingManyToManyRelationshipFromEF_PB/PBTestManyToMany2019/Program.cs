//This is my new version of pbTestManyToMany which was produced in 2013
//This version uses EF6 Code-First to produce the Books.mdf
//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms
//14 January 2020 I have decided to abandon the idea of auto databinding, since using ObservableListSource
//makes it very difficult to access the joining table
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBTestManyToMany2019
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
