//https://www.entityframeworktutorial.net/entityframework6/create-entity-data-model.aspx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DBFirst01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SampleDatabaseEntities())
            {
                var order = new Order()
                {
                    OrderDate = DateTime.Parse("3/4/2008"),
                    OrderQuantity = 23
                };
                
                var cust = new Customer()
                {
                    CustomerID = "Cust3",
                    CompanyName = "CoName3",
                    ContactName = "Contact3"
                    //Phone = "PhoneNumber4"
                };

                context.Customers.Add(cust);
                context.SaveChanges();
            }
            Console.WriteLine("Press a key");
            Console.ReadKey();
            Console.WriteLine("Key has been pressed");
        }
    }
}
