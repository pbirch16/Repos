//https://social.msdn.microsoft.com/Forums/en-US/97a599b4-3027-45c4-a1b0-210d871b2b92/adding-a-many-to-many-relationship-from-ef-in-a-datagridview?forum=winforms
//Adding a many to many relationship from EF in a DataGridView
//11 an 2020 I can't get any further with this. I cannot get the associations right.
//So I have decided to try to work with a known database such as my College database.
//See AddingManyToManyRelationshipFromEF_PB_CF (Code First)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddingManyToManyRelationshipFromEF_PB_DBF
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
