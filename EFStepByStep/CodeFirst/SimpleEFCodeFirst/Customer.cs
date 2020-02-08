//EFSBS Page 15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEFCodeFirst
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string AddressLine1{ get; set; }
        public string AddressLine2 { get; set; }
        public string City{ get; set; }
        public string County{ get; set; }
        public string PostCode{ get; set; }
        public string Country{ get; set; }

        //Provide the linkage to the purchase class
        public virtual List<Purchase> Purchases { get; set; }
    }
}
