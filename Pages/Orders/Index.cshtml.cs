using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_eshop.Data;
using Proiect_eshop.Models;

namespace Proiect_eshop.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_eshop.Data.Proiect_eshopContext _context;

        public IndexModel(Proiect_eshop.Data.Proiect_eshopContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(o => o.Member)
                .Include(o => o.Product)
                .ThenInclude(o => o.Supplier)
                .ToListAsync();
            }
        }
    }
}
