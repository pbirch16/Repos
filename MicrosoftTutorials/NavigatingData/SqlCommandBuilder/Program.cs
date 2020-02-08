//SqlCommandBuilder Class
//https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommandbuilder?view=netframework-4.8
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlCommandBuilderExample
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
            Application.Run(new frmSqlCommandBuilder());
        }
    }
}
