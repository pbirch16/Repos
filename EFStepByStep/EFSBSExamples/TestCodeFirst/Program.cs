//EF Step By Step Page 57
//Creating a code-first example
//Page 57 (Creating a code-first example)
//Page 66 (Creating a model-first example)  I have tried to incorporate the ideas from here onwards
// into this code-first example. (I have stuck with Rewards.mdf database rather than Rewards2.mdf
//Page 77 et seq
//Page 106 et seq
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCodeFirst
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
            Application.Run(new frmTestCodeFirst());
        }
    }
}
