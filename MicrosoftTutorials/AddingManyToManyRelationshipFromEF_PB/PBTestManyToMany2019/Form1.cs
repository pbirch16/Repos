//https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms#add-the-code-that-handles-data-interaction
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

namespace PBTestManyToMany2019
{
    public partial class Form1 : Form
    {
        private BooksContext _ctx;
        public Form1()
        {
            InitializeComponent();
            //InitDatabase();
            //SetupTestData();
            //SetupTestLinks();
            //DisplayData();
            //List<DTOGenericObject> dot= GetRefByBook(4);
        }

        private void InitDatabase()
        {
            using (var ctx = new BooksContext())
            {
                var book = new Book() { BookTitle = "Book5" };
                ctx.Books.Add(book);
                ctx.SaveChanges();
            }
            MessageBox.Show("Database Created?");
        }


        private void SetupTestData()
        {
            for (int i = 1; i < 6; i++)
            {
                CreateBook("Book" + i.ToString());
            }

            for (int i = 1; i < 8; i++)
            {
                CreateRef("Ref" + i.ToString());
            }

            MessageBox.Show("Test Data Created");
        }


        private void SetupTestLinks()
        {
            CreateLink(4, 3);
            CreateLink(4, 5);
            MessageBox.Show("Links Created");
        }

        private void DisplayData()
        {
            using (var ctx = new BooksContext())
            {
                foreach (var bk in ctx.Books)
                {
                    Console.WriteLine("BookId: {0}  Book Title: {1}", bk.BookId.ToString(), bk.BookTitle);
                }

                Console.WriteLine();

                foreach (var rf in ctx.Refs)
                {
                    Console.WriteLine("RefId: {0}  Ref Name: {1}", rf.RefId.ToString(), rf.RefName);
                }

                foreach (var bk in ctx.Books)
                {
                    //Console.WriteLine("BookId: {0}  Book Title: {1}", bk.BookId.ToString(), bk.BookTitle);
                    //foreach (var r in ctx.Books.r)
                    //{

                    //}
                }

                Console.WriteLine();
            }
        }

        private void CreateBook(string bookTitle)
        {
            using (var ctx = new BooksContext())
            {
                var book = new Book() { BookTitle = bookTitle };
                ctx.Books.Add(book);
                ctx.SaveChanges();
            }
        }


        private void CreateRef(string refName)
        {
            using (var ctx = new BooksContext())
            {
                var r = new Ref() { RefName = refName };
                ctx.Refs.Add(r);
                ctx.SaveChanges();
            }
        }

        private void CreateLink(int bookId, int refId)
        {
            using (var ctx = new BooksContext())
            {
                Book b = new Book { BookId = bookId };
                ctx.Books.Add(b);
                ctx.Books.Attach(b);

                Ref r = new Ref { RefId = refId };
                ctx.Refs.Add(r);
                ctx.Refs.Attach(r);

                b.Refs.Add(r);

                ctx.SaveChanges();
            }
        }


        private List<DTOGenericObject> GetRefByBook(int bookId)
        {
            using (var ctx = new BooksContext())
            {
                var result =
                    //get instance from context
                    (from a in ctx.Books
                         //instance from navigation property
                     from b in a.Refs
                         //join to bring useful data
                     join c in ctx.Refs on b.RefId equals c.RefId
                     where a.BookId == bookId
                     select new DTOGenericObject
                     {
                         ID = c.RefId,
                         Name = c.RefName
                     }).ToList();
                return result;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            string s = sender.ToString();
            string E = e.ToString();

        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    //using (var ctx = new BooksContext())
        //    var ctx = new BooksContext();
        //    ctx.Books.Load();
        //    bookBindingSource.DataSource = ctx.Books.Local.ToBindingList();
        //}



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _ctx = new BooksContext();

            // Call the Load method to get the data for the given DbSet
            // from the database.
            // The data is materialized as entities. The entities are managed by
            // the DbContext instance.
            _ctx.Refs.Load();

            // Bind the categoryBindingSource.DataSource to
            // all the Unchanged, Modified and Added Category objects that
            // are currently tracked by the DbContext.
            // Note that we need to call ToBindingList() on the
            // ObservableCollection<TEntity> returned by
            // the DbSet.Local property to get the BindingList<T>
            // in order to facilitate two-way binding in WinForms.
            //this.refBindingSource.DataSource =
            //    _ctx.Refs.Local.ToBindingList();

            _ctx.Books.Load();
            this.bookBindingSource.DataSource = _ctx.Books.Local.ToBindingList();
        }

        private void refBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();

            //Currently, the Entity Framework doesn’t mark the entities
            // that are removed from a navigation property(in our example the Products)
            // as deleted in the context.
            // The following code uses LINQ to Objects against the Local collection
            // to find all products and marks any that do not have
            // a Category reference as deleted.
            // The ToList call is required because otherwise
            // the collection will be modified
            // by the Remove call while it is being enumerated.
            // In most other situations you can do LINQ to Objects directly
            // against the Local property without using ToList first.
            //foreach (var book in _ctx.Books.Local.ToList())
            //{
            //    if (book.Refs == null)
            //    {
            //        _ctx.Books.Remove(book);
            //    }
            //}

            foreach (var r in _ctx.Refs.Local.ToList())
            {
                if (r.Books == null)
                {
                    _ctx.Refs.Remove(r);
                }
            }

            _ctx.SaveChanges();


            // Refresh the controls to show the values
            // that were generated by the database.
            //refDataGridView.Refresh();
            bookDataGridView.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this._ctx.Dispose();
        }


    }
}
