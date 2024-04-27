﻿using EcommerceDBProject.NewF;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForCustomerDashboard
    {
        public List<InventoryItem> AllInventoryItems { get; set; } = new();
        public string SelectedCetagory { get; set; } = null;
        public List<BuyInventoryItemViewModel> BuyInventoryItemList { get; set; } = new();
        public List<ProductCategory> ProductCategories { get; set; } = new();  
    }

    public class BuyInventoryItemViewModel
    {
        public InventoryItem InventoryItem { get; set; }
        public int QuantityToBuy { get; set; }
    }
}
