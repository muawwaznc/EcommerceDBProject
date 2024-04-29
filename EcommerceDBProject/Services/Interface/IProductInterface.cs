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
    }
}
