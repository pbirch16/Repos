using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rewards;


namespace TestRewardsCLib
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new purchase
            Purchase NewPurchase = new Purchase()
            {
                Amount = new Decimal(18.65),
                PurchaseDate = DateTime.Now
            };

            //Create a new customer and add the purchase
            Customer NewCustomer = new Customer()
            {
                CustomerName = "Henry Crun"
            };

            //Create the context
            using (RewardsContext ctx = new RewardsContext())
            {
                ctx.Customers.Add(NewCustomer);
                ctx.Purchases.Add(NewPurchase);
                ctx.SaveChanges();

                Console.WriteLine("Record Added");
                Console.ReadKey();
            }
        }
    }
}
