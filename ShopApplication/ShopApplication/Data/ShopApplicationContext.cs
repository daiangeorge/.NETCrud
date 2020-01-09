using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;

namespace ShopApplication.Data
{
    public class ShopApplicationContext : DbContext
    {
        public ShopApplicationContext (DbContextOptions<ShopApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ShopApplication.Models.Customer> Customer { get; set; }

        public DbSet<ShopApplication.Models.CustomerProduct> CustomerProduct { get; set; }

        public DbSet<ShopApplication.Models.Product> Product { get; set; }
    }
}
