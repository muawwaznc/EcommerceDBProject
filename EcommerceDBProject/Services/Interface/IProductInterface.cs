using EcommerceDBProject.DBContext;
using EcommerceDBProject.ViewModels;
using static EcommerceDBProject.ViewModels.InitialPageDataforUpdateDeleteSupplier;

namespace EcommerceDBProject.Services.Interface
{
    public interface IProductInterface
    {
        List<ComboBoxItemsViewModel> GetAllCategoriesForDropDown();
        List<ProductCategory> GetAllProductCategories();
        List<SupplierInfoViewModel> GetAllSupplierDetails();
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
        List<Product> GetAllProductsByCategoryId(string categoryId);
        List<ProductViewModel> RefreshProductsList();
        void UpdateSupplier(SupplierInfoViewModel supplierInfoViewModel);
        List<ProductViewModel> GetProductViewModelList();
    }
}
