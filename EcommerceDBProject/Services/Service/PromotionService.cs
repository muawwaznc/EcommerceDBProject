using EcommerceDBProject.EcomDbContext;
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
        public List<Promotion> GetAllPromotionList()
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var promotionList = db.Promotions.ToList();
                return promotionList;
            }            
        }
        public bool IsPromotionNameAlreadyExist(string promotionName)
        {
            var promotionList = GetAllPromotionList();
            foreach (var item in promotionList)
            {
                if (item.PromotionName == promotionName)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdatePromotion(Promotion promotion)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                db.Promotions.Update(promotion);
                db.SaveChanges();
            }
        }

        public void DeletePromotion(Promotion promotion)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                try
                {
                    db.Promotions.Remove(promotion);
                    db.SaveChanges();
                }
                catch(Exception)
                {
                    var productPromotions = db.ProductPromotions.Where(x => x.PromotionId == promotion.PromotionId);
                    db.ProductPromotions.RemoveRange(productPromotions);
                    db.Promotions.Remove(promotion);
                    db.SaveChanges();
                }
                
            }
        }
    }
}
