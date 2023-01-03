namespace Proiect_eshop.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }

    }
}
