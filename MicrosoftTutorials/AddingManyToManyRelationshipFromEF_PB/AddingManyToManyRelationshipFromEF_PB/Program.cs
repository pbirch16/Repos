//https://social.msdn.microsoft.com/Forums/en-US/97a599b4-3027-45c4-a1b0-210d871b2b92/adding-a-many-to-many-relationship-from-ef-in-a-datagridview?forum=winforms
//Adding a many to many relationship from EF in a DataGridView
//Microsoft Social Forums
//See E:\Visual Studio 2019\Books\Microsoft\Adding a many to many relationship from EF
//on which this is based.
//Also see E:\Visual Studio 2019\Source\Projects.docx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddingManyToManyRelationshipFromEF_PB
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
            Application.Run(new frmM2MFromEF());
        }
    }
}
