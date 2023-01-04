using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_eshop.Data;
using Proiect_eshop.Models;

namespace Proiect_eshop.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public CreateModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "ID", "SupplierName");

            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);

            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = Product;
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }

            _context.Product.Add(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, newProduct);
            return Page();
        }
    }
}
