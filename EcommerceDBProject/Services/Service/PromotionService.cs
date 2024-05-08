using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;

namespace EcommerceDBProject.Services.Service
{
    public class PromotionService : IPromotionInterface
    {
        public void AddPromotion(Promotion promotion)
        {
            using (var db = new EcommerceDbContext())
            {
                db.Promotions.Add(promotion);
                db.SaveChanges();
            }
        }

        public List<Promotion> GetAllPromotionList()
        {
            using (var db = new EcommerceDbContext())
            {
                var promotionList = db.Promotions.ToList();
                return promotionList;
            }
        }

        public List<Promotion> GetAllActivePromotionsList()
        {
            using (var db = new EcommerceDbContext())
            {
                var promotionList = db.Promotions.Where(x => x.EndDate >= DateTime.Now).ToList();
                return promotionList;
            }
        }

        public bool IsPromotionNameAlreadyExist(Promotion promotion)
        {
            var promotionList = GetAllPromotionList();
            foreach (var item in promotionList)
            {
                if (item.PromotionName == promotion.PromotionName)
                {
                    if(promotion.StartDate < item.StartDate && promotion.EndDate < item.StartDate)
                    {
                        return false;
                    }
                    else if(promotion.StartDate > item.EndDate)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public void UpdatePromotion(Promotion promotion)
        {
            using(var db = new EcommerceDbContext())
            {
                db.Promotions.Update(promotion);
                db.SaveChanges();
            }
        }

        public void DeletePromotion(Promotion promotion)
        {
            using (var db = new EcommerceDbContext())
            {
                try
                {
                    db.Promotions.Remove(promotion);
                    db.SaveChanges();
                }
                catch(Exception)
                {
                    var productPromotions = db.ProductPromotions.Where(x => x.PromotionId == promotion.PromotionId).ToList();
                    db.ProductPromotions.RemoveRange(productPromotions);
                    db.Promotions.Remove(promotion);
                    db.SaveChanges();
                }
                
            }
        }

        public bool AddProductPromotion(ProductPromotion productPromotion)
        {
            using(var db = new EcommerceDbContext())
            {
                try
                {
                    db.ProductPromotions.Add(productPromotion);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }                
            }
        }
    }
}
