using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;

namespace EcommerceDBProject.Services.Service
{
    public class SellerService: ISellerInterface
    {
        public Seller GetSellerFromSellerId(string sellerId)
        {
            using (var db = new EcommerceDbContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.SellerId == sellerId);
                return seller;
            }
        }

        public string GetSellerFullNameFromSellerId(string sellerId)
        {
            using (var db = new EcommerceDbContext())
            {
                var seller = db.Sellers.FirstOrDefault(x => x.SellerId == sellerId);
                return seller.LastName + ", " + seller.FirstName;
            }
        }
    }
}
