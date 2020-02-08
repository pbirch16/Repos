//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
//Configure Many-to-Many Relationships in Code-First
//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms
//Databinding with WinForms
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Many2ManyExample01
{
    static class M2MProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMany2Many());
        }
    }
}
