//This is based on my 2013 project pbTestManyToMany3
//https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbTestManyToMany3_CF
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
            //Application.Run(new frmDbMaint());
        }
    }
}
