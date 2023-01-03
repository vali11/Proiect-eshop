namespace Proiect_eshop.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public int TIN { get; set; } //tax identification number - in RO - CIF
        public ICollection<Product>? Products { get; set; } //navigation property

    }
}
