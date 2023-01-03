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
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public EditModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.Include(p => p.Supplier)
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (product == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Product);
            Product = product;
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "ID", "SupplierName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
            selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productToUpdate = await _context.Product
                .Include(i => i.Supplier)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Product>(
                productToUpdate, "Product",
                i => i.Name, i => i.Description,
                i => i.Price, i => i.SupplierID))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();

        }
    }
}
