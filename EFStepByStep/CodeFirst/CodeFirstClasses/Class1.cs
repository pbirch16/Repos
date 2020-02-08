using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CodeFirstClasses
{
    public class Customer
    {
    //This is copied from Page 70 ModelFirst for Rewards2

    public Customer()
    {
            this.Purchases = new HashSet<Purchase>();
    }
        //Identify the individual customer
        public Int32 CustomerId { get; set; }
        public String CustomerName { get; set; }

        //Provide the linkage to the purchase class
        public virtual ICollection<Purchase> Purchases { get; set; } //Why is this ICollection rather than List?
    }

    public class Purchase
    {
        //Define the individual purchase entries
        public Int32 PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Decimal Amount { get; set; }

        //Store the customer's identifier for this record
        public Int32 CustomerId { get; set; }
    }

    public class RewardsContext : DbContext
    {
        //Specify the name of the database as Rewards
        public RewardsContext() : base("Name=RewardsCS")
        {
            throw new UnintentionalCodeFirstException();
        }
        
        //Create a database set for each of the data items
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
