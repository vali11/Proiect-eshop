using Proiect_eshop.Models;
using System.Security.Policy;

namespace Proiect_eshop.Models.ViewModels
{
    public class SupplierIndexData
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
