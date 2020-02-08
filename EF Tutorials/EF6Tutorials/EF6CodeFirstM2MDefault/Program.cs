//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
//Configure Many-to-Many Relationships in Code-First
//Many-to-Many Relationship by Following Conventions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF6CodeFirstM2MDefault
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
            Application.Run(new frmCFM2MDefault());
        }
    }
}
