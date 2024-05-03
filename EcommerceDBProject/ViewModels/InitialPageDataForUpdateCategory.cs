using EcommerceDBProject.EcomDbContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForUpdateCategory
    {
        public List<ProductCategory> CategoriesList { get; set; } = new();
        public ProductCategory SelectedCategory { get; set; } = new();
        public bool IsEditDialogBoxOpen { get; set; } = false;
    }
}
