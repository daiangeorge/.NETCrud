using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    public class CustomerProduct
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }


    }
}
