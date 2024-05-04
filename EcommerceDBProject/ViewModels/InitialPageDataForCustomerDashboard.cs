using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForCustomerDashboard
    {
        public List<InventoryItem> AllInventoryItems { get; set; } = new();
        public List<BuyInventoryItemViewModel> BuyInventoryItemList { get; set; } = new();
        public List<ProductCategory> ProductCategories { get; set; } = new();
        public CustomerDetailViewModel CustomerDetailViewModel { get; set; } = new();
        public bool IsOrderModelShow { get; set; } = false;
        public bool IsOrderProcessing { get; set; } = false;
    }

    public class CustomerDetailViewModel
    {
        public string UserDetailId { get; set; }
        public Address ShippingAddress { get; set; } = new();
        public string PaymentMethod { get; set; }
        public string ShippingMethod { get; set; }
    }

    public class BuyInventoryItemViewModel
    {
        public InventoryItem InventoryItem { get; set; }
        public int QuantityToBuy { get; set; }
        
    }
}
