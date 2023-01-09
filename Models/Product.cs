using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_eshop.Models
{
    public class Product
    {
        public int ID { get; set; }
        [StringLength(70, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        [Required]
        public decimal Price { get; set; }

        public int? SupplierID { get; set; }
        public Supplier? Supplier { get; set; } //navigation property 

        public ICollection<ProductCategory>? ProductCategories { get; set; }


    }
}
