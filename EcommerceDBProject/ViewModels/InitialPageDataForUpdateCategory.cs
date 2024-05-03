using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForUpdateCategory
    {
        public List<ProductCategory> CategoriesList { get; set; } = new();
        public ProductCategory SelectedCategory { get; set; } = new();
        public string SelectedProductCategoryId { get; set; }
        public bool IsEditDialogBoxOpen { get; set; } = false;
    }
}
