using EcommerceDBProject.DBContext;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IProductInterface
    {
        List<ComboBoxItemsViewModel> GetAllCategoriesForDropDown();
        List<ProductCategory> GetAllProductCategories();
        Product GetProductFromProductId(string productId);
        ProductCategory GetProductCategoryFromProductCategoryId(string categoryId);
        Product GetProductFromInventoryItemId(string inventoryItemId);
        void AddProductCategory(ProductCategory category);
        bool IsCategoryNameAlreadyExist(string categoryName);
        List<Supplier> GetAllSuppliers();
    }
}
