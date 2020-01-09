using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApplication.Data;
using ShopApplication.Models;

namespace ShopApplication.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly ShopApplication.Data.ShopApplicationContext _context;

        public CreateModel(ShopApplication.Data.ShopApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "ID");
        ViewData["ProductID"] = new SelectList(_context.Set<Product>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public CustomerProduct CustomerProduct { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CustomerProduct.Add(CustomerProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}