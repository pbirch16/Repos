//E:\Visual Studio 2019\Books\Microsoft\Adding a many to many relationship from EF\Adding a many to many relationship from EF\Adding a many to many relationship from EF\
//https://social.msdn.microsoft.com/Forums/en-US/97a599b4-3027-45c4-a1b0-210d871b2b92/adding-a-many-to-many-relationship-from-ef-in-a-datagridview?forum=winforms
//Adding a many to many relationship from EF in a DataGridView
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddingManyToManyRelationshipFromEF_PB_CF_CollegeDB
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
