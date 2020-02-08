//The use of this class makes it very difficult to access the constituent classes - so I have decided
//to go back to the original method of generating the database
//https://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBTestManyToMany2019
{
    public class Book
    {
        //public ObservableListSource<Ref> _refs =
        //    new ObservableListSource<Ref>();
        public Book()
        {
            Refs = new HashSet<Ref>();
        }


        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        
        public virtual ICollection<Ref> Refs{ get; set; }

        //public virtual Ref Ref { get; set; }
        //public virtual ObservableListSource<Ref> Refs
        //{
        //    get { return _refs; }
        //    set { _refs = value; }
        //}
    }
}
