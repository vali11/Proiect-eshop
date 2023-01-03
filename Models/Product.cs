using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_eshop.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        public int? SupplierID { get; set; }
        public Supplier? Supplier { get; set; } //navigation property 

        public ICollection<ProductCategory>? ProductCategories { get; set; }


    }
}
