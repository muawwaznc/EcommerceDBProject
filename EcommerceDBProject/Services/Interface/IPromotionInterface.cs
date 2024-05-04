using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.Services.Interface
{
    public interface IPromotionInterface
    {
        void AddPromotion(Promotion promotion);
        List<Promotion> GetAllPromotionList();
        bool IsPromotionNameAlreadyExist(Promotion promotion);
        void UpdatePromotion(Promotion promotion);
        void DeletePromotion(Promotion promotion);
    }
}
