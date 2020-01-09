using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Models;

namespace ShopApplication.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly ShopApplication.Data.ShopApplicationContext _context;

        public EditModel(ShopApplication.Data.ShopApplicationContext context)
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
           ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "ID");
           ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CustomerProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerProductExists(CustomerProduct.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerProductExists(int id)
        {
            return _context.CustomerProduct.Any(e => e.ID == id);
        }
    }
}
