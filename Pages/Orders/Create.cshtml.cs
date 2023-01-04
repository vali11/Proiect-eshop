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

namespace Proiect_eshop.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public CreateModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var productList = _context.Product
            .Include(p => p.Supplier)
            .Select(x => new
            {
            x.ID,
            ProductFullName = x.Name + " - " + x.Supplier.SupplierName
            });

            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            ViewData["ProductID"] = new SelectList(productList, "ID", "ProductFullName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
