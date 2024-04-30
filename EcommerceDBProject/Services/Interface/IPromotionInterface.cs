using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.Services.Interface
{
    public interface IPromotionInterface
    {
        void AddPromotion(Promotion promotion);
        List<Promotion> GetAllProductPromotion();
        bool IsPromotionNameAlreadyExist(string promotionName);
    }
}
