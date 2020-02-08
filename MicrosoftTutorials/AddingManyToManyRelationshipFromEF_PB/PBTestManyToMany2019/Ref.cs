using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBTestManyToMany2019
{
    public class Ref
    {
        //public readonly ObservableListSource<Book> _books =
        //    new ObservableListSource<Book>();

        public Ref()
        {
            Books = new HashSet<Book>();
        }

        public int RefId{ get; set; }
        public string RefName{ get; set; }

        public virtual ICollection<Book> Books{ get; set; }

        //public virtual ObservableListSource <Book> Books{ get { return _books; } }
    }
}
