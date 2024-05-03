using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IProductInterface
    {
        List<ComboBoxItemsViewModel> GetAllCategoriesForDropDown();
        List<ProductCategory> GetAllProductCategories();
        Product GetProductFromProductId(string productId);
        Product GetProductFromInventoryItemId(string inventoryItemId);
        void AddProductCategory(ProductCategory category);
        bool IsCategoryNameAlreadyExist(string categoryName);
        List<Supplier> GetAllSuppliers();
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        ProductCategory GetProductCategoryByCategoryId(string categoryId);
        Supplier GetSupplierBySupplierId(string supplierId);
        void UpdateProduct(Product product);
        void UpdateProductCategory(ProductCategory productCategory);
        bool DeleteProduct(Product product);
        bool DeleteProductCategory(ProductCategory productCategory);
    }
}
