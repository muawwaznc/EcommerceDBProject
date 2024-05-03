using EcommerceDBProject.EcomDbContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForAddProduct
    {
        public List<ProductCategory> ProductCategoriesList { get; set; } = new();
        public List<Supplier> SuppliersList { get; set; } = new();
        public Product Product { get; set; } = new();
    }
}
