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
    public class DetailsModel : PageModel
    {
        private readonly ShopApplication.Data.ShopApplicationContext _context;

        public DetailsModel(ShopApplication.Data.ShopApplicationContext context)
        {
            _context = context;
        }

        public CustomerProduct CustomerProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerProduct = await _context.CustomerProduct
                .Include(c => c.Customer)
                .Include(c => c.Product).SingleOrDefaultAsync(m => m.ID == id);

            if (CustomerProduct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
