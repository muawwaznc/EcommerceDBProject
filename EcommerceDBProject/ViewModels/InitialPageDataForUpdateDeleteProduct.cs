using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForUpdateDeleteProduct
    {
        public List<ProductViewModel> Products { get; set; } = new();
        public List<ProductCategory> CategoriesList { get; set; } = new();
        public List<Supplier> SuppliersList { get; set; } = new();
        public ProductViewModel SelectedProduct { get; set; } = new();
        public string SelectedSupplierId { get; set; }
        public string SelectedProductCategoryId { get; set; }
        public bool IsEditDialogBoxOpen { get; set; } = false;
    }

    public class ProductViewModel 
    {
        public Product Product { get; set; }
        public ProductCategory Category { get; set; }
        public Supplier Supplier { get; set; }
    }

}
