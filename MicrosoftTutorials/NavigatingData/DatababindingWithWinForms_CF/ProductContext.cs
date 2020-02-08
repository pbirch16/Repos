using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatababindingWithWinForms_CF
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=ProductsCFConnectionString")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
