using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForUpdateDeletePromotion
    {
        public List<Promotion> PromotionsList { get; set; } = new();
        public Promotion SelectedPromotion { get; set; } = new();
        public bool IsEditDialogBoxOpen { get; set; } = false;
    }
}
