using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_eshop.Data;
using Proiect_eshop.Models;
using Proiect_eshop.Models.ViewModels;

namespace Proiect_eshop.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public IndexModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;

        public SupplierIndexData SupplierData { get; set; }
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            SupplierData = new SupplierIndexData();
            SupplierData.Suppliers = await _context.Supplier
            .Include(i => i.Products)
            .OrderBy(i => i.SupplierName)
            .ToListAsync();
            if (id != null)
            {
                SupplierID = id.Value;
                Supplier supplier = SupplierData.Suppliers
                .Where(i => i.ID == id.Value).Single();
               SupplierData.Products = supplier.Products;
            }
        }
    }
}
