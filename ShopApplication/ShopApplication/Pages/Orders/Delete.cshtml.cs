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
    public class DeleteModel : PageModel
    {
        private readonly ShopApplication.Data.ShopApplicationContext _context;

        public DeleteModel(ShopApplication.Data.ShopApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerProduct = await _context.CustomerProduct.FindAsync(id);

            if (CustomerProduct != null)
            {
                _context.CustomerProduct.Remove(CustomerProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
