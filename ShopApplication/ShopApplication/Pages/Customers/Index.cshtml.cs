using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Models;

namespace ShopApplication.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ShopApplication.Data.ShopApplicationContext _context;

        public IndexModel(ShopApplication.Data.ShopApplicationContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
