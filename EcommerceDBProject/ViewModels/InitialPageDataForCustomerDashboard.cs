using EcommerceDBProject.NewF;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForCustomerDashboard
    {
        public List<InventoryItem> AllInventoryItems { get; set; } = new();
        public List<BuyInventoryItemViewModel> BuyInventoryItemList { get; set; } = new();
        public List<ProductCategory> ProductCategories { get; set; } = new();
        public CustomerDetailViewModel CustomerDetailViewModel { get; set; } = new();
    }

    public class CustomerDetailViewModel
    {
        public string UserDetailId { get; set; }
        public Address ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingMethod { get; set; }
    }

    public class BuyInventoryItemViewModel
    {
        public InventoryItem InventoryItem { get; set; }
        public int QuantityToBuy { get; set; }
        
    }
}
