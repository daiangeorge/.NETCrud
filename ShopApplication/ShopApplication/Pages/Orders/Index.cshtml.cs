using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Models;

namespace ShopApplication.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ShopApplication.Data.ShopApplicationContext _context;

        public IndexModel(ShopApplication.Data.ShopApplicationContext context)
        {
            _context = context;
        }

        public IList<CustomerProduct> CustomerProduct { get;set; }

        public async Task OnGetAsync()
        {
            CustomerProduct = await _context.CustomerProduct
                .Include(c => c.Customer)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
