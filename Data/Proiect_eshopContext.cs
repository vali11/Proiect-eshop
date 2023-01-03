using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_eshop.Models;

namespace Proiect_eshop.Data
{
    public class Proiect_eshopContext : DbContext
    {
        public Proiect_eshopContext (DbContextOptions<Proiect_eshopContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_eshop.Models.Product> Product { get; set; } = default!;

        public DbSet<Proiect_eshop.Models.Supplier> Supplier { get; set; }

        public DbSet<Proiect_eshop.Models.Category> Category { get; set; }
    }
}
