using System.ComponentModel.DataAnnotations;

namespace Proiect_eshop.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string SupplierName { get; set; }
        [Required]
        public string SupplierAddress { get; set; }
        [Required]
        public int TIN { get; set; } //tax identification number - in RO - CIF
        public ICollection<Product>? Products { get; set; } //navigation property

    }
}
