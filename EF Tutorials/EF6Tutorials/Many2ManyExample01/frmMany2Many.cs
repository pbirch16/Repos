//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Many2ManyExample01
{
    public partial class frmMany2Many : Form
    {
        CollegeContext _context;
        public frmMany2Many()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new CollegeContext();

            // Call the Load method to get the data for the given DbSet
            // from the database.
            // The data is materialized as entities. The entities are managed by
            // the DbContext instance.
            _context.Courses.Load();

            // Bind the courseBindingSource.DataSource to
            // all the Unchanged, Modified and Added Category objects that
            // are currently tracked by the DbContext.
            // Note that we need to call ToBindingList() on the
            // ObservableCollection<TEntity> returned by
            // the DbSet.Local property to get the BindingList<T>
            // in order to facilitate two-way binding in WinForms.
            this.courseBindingSource.DataSource = _context.Courses.Local.ToBindingList();
        }
        private void courseBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

            // Currently, the Entity Framework doesn’t mark the entities
            // that are removed from a navigation property (in our example the Products)
            // as deleted in the context.
            // The following code uses LINQ to Objects against the Local collection
            // to find all products and marks any that do not have
            // a Category reference as deleted.
            // The ToList call is required because otherwise
            // the collection will be modified
            // by the Remove call while it is being enumerated.
            // In most other situations you can do LINQ to Objects directly
            // against the Local property without using ToList first.
            foreach (var student in _context.Students.Local.ToList())
            {
                if (student.)
                {

                }
            }
        }
    }
}
