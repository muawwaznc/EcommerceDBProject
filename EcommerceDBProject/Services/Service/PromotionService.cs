using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;

namespace EcommerceDBProject.Services.Service
{
    public class PromotionService : IPromotionInterface
    {
        public void AddPromotion(Promotion promotion)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                db.Promotions.Add(promotion);
                db.SaveChanges();
            }
        }
        public List<Promotion> GetAllProductPromotion()
        {
            var db = new EcommerceDbprojectContext();
            var PromotionList = db.Promotions.ToList();
            return PromotionList;
        }
        public bool IsPromotionNameAlreadyExist(string promotionName)
        {
            var PromotionList = GetAllProductPromotion();
            foreach (var item in PromotionList)
            {
                if (item.PromotionName == promotionName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
