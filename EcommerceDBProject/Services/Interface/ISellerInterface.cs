using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.Services.Interface
{
    public interface ISellerInterface
    {
        Seller GetSellerFromSellerId(string sellerId);
        string GetSellerFullNameFromSellerId(string sellerId);
    }
}
