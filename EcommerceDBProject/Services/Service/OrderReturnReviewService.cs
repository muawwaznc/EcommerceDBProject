using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;

namespace EcommerceDBProject.Services.Service
{
    public class OrderReturnReviewService : IOrderReturnReviewInterface
    {
        public bool IsReturnAvailable(string orderItemId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var produtReturn = db.ProductReturns.FirstOrDefault(x => x.OrderItemId == orderItemId);
                if(produtReturn != null) 
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsReviewAvailable(string orderItemId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var produtReview = db.ProductReviews.FirstOrDefault(x => x.OrderItemId == orderItemId);
                if (produtReview != null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
