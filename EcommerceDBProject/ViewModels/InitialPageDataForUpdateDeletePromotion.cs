using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForUpdateDeletePromotion
    {
        public List<Promotion> PromotionsList { get; set; } = new();
        public Promotion SelectedPromotion { get; set; } = new();
        public string SelectedPromotionId { get; set; }
        public bool IsEditDialogBoxOpen { get; set; } = false;
    }
}
