using EcommerceDBProject.DBContext;

namespace EcommerceDBProject.ViewModels
{
    public class InitialPageDataForSellerProfile
    {
        public UserDetail UserDetail { get; set; } = new();
        public Seller Seller { get; set; } = new();
        public Address Address { get; set; } = new();
    }
}
