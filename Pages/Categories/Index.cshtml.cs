using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_eshop.Data;
using Proiect_eshop.Models;
using Proiect_eshop.Models.ViewModels;

namespace Proiect_eshop.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public IndexModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int ProductID { get; set; }

        public async Task OnGetAsync(int? id, int? BookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.ProductCategories)
            .ThenInclude(i => i.Product)
            .ThenInclude(i => i.Supplier)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.ProductCategories = category.ProductCategories;
            }
        }
    }
}
