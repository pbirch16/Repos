//See E:\Visual Studio 2013\Projects\MSDN Examples\Database Examples\pbTestManyToMany\
//Which was written in 2013
//this is my attempt at rewriting it with an updated version of the Projects Database, using Database First to import it
//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbTestManyToMany_DBF
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
