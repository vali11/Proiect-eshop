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

        public string NameSort { get; set; }
        public string PriceSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            CurrentFilter = searchString;

            ProductD = new ProductData();
            ProductD.Products = await _context.Product.Include(p => p.Supplier).Include(p => p.ProductCategories).ThenInclude(p => p.Category).AsNoTracking().OrderBy(p => p.Name).ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                ProductD.Products = ProductD.Products.Where(s => s.Supplier.SupplierName.Contains(searchString)
               || s.Name.Contains(searchString));

                if (id != null) { ProductID = id.Value; Product product = ProductD.Products.Where(i => i.ID == id.Value).Single(); ProductD.Categories = product.ProductCategories.Select(s => s.Category); }
            switch (sortOrder)
            {
                case "name_desc":
                    ProductD.Products = ProductD.Products.OrderByDescending(s => s.Name);
                    break;
                case "price_desc":
                    ProductD.Products = ProductD.Products.OrderByDescending(s => s.Price);
                    break;

            }

        }

    }
}
