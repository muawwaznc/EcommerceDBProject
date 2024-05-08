using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForSellerBuyProducts
    {
        public List<ProductViewModel> ProductList { get; set; } = new();
        public List<ProductCategory> ProductCategories { get; set; } = new();
        public bool BuyProductDialogBoxOpen { get; set; } = false;
        public BuyProductViewModel BuyProductViewModel { get; set; } = new();
    }

    public class BuyProductViewModel
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }        
        public int SalePrice { get; set; }
        public string Condition { get; set; }
    }
}
