using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApplication.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        //Adaugat ulterior
        public string Email { get; set; }
        public int CustomerProductID { get; set; }
        public ICollection<CustomerProduct> CustomerProducts { get; set; }

    }
}
