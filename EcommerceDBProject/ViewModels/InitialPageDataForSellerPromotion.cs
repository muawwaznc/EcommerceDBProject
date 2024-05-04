using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForSellerPromotion
    {
        public string SellerId { get; set; }
        public List<Promotion> PromotionList { get; set; } = new();
        public List<ProductCategory> ProductCategoriesList { get; set; } = new();
        public List<InventoryItem> InventoryItemsList { get; set; } = new();
        public bool ApplyPromotionDialogBox { get; set; }
        public string SelectedCategoryId { get; set; } 
        public string SelectedInventoryItemId { get; set; }
        public string SelectedPromotionId { get; set; }
    }
}
