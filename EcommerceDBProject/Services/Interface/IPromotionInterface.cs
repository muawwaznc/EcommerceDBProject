using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.Services.Interface
{
    public interface IPromotionInterface
    {
        void AddPromotion(Promotion promotion);
        List<Promotion> GetAllPromotionList();
        bool IsPromotionNameAlreadyExist(string promotionName);
    }
}
