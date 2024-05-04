using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForSellerPromotion
    {
        public string SellerId { get; set; }
        public List<Promotion> PromotionList { get; set; } = new();
        public List<ProductCategory> productCategoriesList { get; set; } = new();
        public List<InventoryItem> inventoryItemsList { get; set; } = new();
        public bool ApplyPromotionDialogBox { get; set; }
        public string SelectedCategoryId { get; set; } 
        public string SelectedInventoryItemId { get; set; }
    }
}
