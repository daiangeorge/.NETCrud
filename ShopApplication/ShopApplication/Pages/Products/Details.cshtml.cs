using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Models;

namespace ShopApplication.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ShopApplication.Data.ShopApplicationContext _context;

        public DetailsModel(ShopApplication.Data.ShopApplicationContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.SingleOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
