//https://entityframework.net/many-to-many-relationship
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBTestManyToMany2019
{
    public class BooksRefs
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }


        [Key, Column(Order = 2)]
        public int RefId { get; set; }

        public Book Book { get; set; }
        public Ref Ref { get; set; }
    }
}
