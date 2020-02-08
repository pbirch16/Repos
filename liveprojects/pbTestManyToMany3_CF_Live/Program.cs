//This Project (A database of my projects) is based on
//E:\Visual Studio 2019\Source\Repos\MicrosoftTutorials\AddingManyToManyRelationshipFromEF_PB\pbTestManyToMany3_CF\
//https://docs.microsoft.com/en-us/ef/ef6/querying/related-data
//http://stackoverflow.com/questions/22898995/linq-select-records-that-match-a-list-of-ids
//https://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework

using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbTestManyToMany3_CF_Live
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
            Application.Run(new frmSwitchBoard());
        }
    }
}
