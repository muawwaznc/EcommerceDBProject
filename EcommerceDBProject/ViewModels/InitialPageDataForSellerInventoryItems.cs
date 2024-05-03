using EcommerceDBProject.EcomDbContext;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.ViewModels
{
    public partial class InitialPageDataForSellerInventoryItems : ComponentBase
    {
        public Seller Seller { get; set; }
        public List<InventoryItem> SellerInventoryItems { get; set; } = new();
        public List<ProductCategory> ProductCategories { get; set; } = new();
        public bool IsInventoryItemEditDialogShow { get; set; } = false;
        public bool IsInventoryItemDeleteDialogShow { get; set; } = false;
    }
}
