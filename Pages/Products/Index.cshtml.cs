using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_eshop.Data;
using Proiect_eshop.Models;

namespace Proiect_eshop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public IndexModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProductD = new ProductData();
            ProductD.Products = await _context.Product.Include(p => p.Supplier).Include(p => p.ProductCategories).ThenInclude(p => p.Category).AsNoTracking().OrderBy(p => p.Name).ToListAsync();
            if (id != null) { ProductID = id.Value; Product product = ProductD.Products.Where(i => i.ID == id.Value).Single(); ProductD.Categories = product.ProductCategories.Select(s => s.Category); }
        }

    }
}
