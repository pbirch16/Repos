//Based on EF Step by Step Page 57 (Creating a code-first example)
//Unlike that example, I have used each class as a separate class (03-01-2020)
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewards
{
    public class RewardsContext : DbContext
    {
        //Specify the name of the database as Rewards
        public RewardsContext() : base("name=PbRewardsCS")
        {

        }

        //Create a database set for each of the data items
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
