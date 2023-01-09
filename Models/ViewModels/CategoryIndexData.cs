namespace Proiect_eshop.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
