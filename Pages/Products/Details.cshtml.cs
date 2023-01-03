using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_eshop.Data;
using Proiect_eshop.Models;

namespace Proiect_eshop.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public DetailsModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

      public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}
