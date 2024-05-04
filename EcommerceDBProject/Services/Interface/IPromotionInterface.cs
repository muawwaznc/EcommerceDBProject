using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.Services.Interface
{
    public interface IPromotionInterface
    {
        void AddPromotion(Promotion promotion);
        List<Promotion> GetAllPromotionList();
        bool IsPromotionNameAlreadyExist(Promotion promotion);
        void UpdatePromotion(Promotion promotion);
        void DeletePromotion(Promotion promotion);
        bool AddProductPromotion(ProductPromotion productPromotion);
    }
}
