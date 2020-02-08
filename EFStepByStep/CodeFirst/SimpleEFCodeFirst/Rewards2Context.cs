using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEFCodeFirst
{
    public class Rewards2Context:DbContext
    {
        //Specify the name of the database as Rewards
        public Rewards2Context() : base("Rewards2CS")
        {

        }

        //Create a database set for each of the data items
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
