using EcommerceDBProject.Enum;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IUserInterface
    {
        UserDetail IsAuthenicated(string email, string password);
        UserDetail SignUp(SignUpModel signUpModel);
        UserRole GetUserRoleByUserDetailId(string userDetailId);
        Customer GetCustomerFromUserDetailId(string userDetailId);
        Address GetAddressByUserDetailId(string userDetailId);
        Seller GetSellerFromSellerId(string sellerId);
        string GetSellerFullNameFromSellerId(string sellerId);
        Seller GetSellerFromUserDetailId(string userDetailId);
        Customer GetCustomerFromCustomerId(string customerId);
        UserDetail GetUserDetailFromUserDetailId(string userDetailId);
        void UpdateSellerDetails(InitialPageDataForSellerProfile sellerData);
        void UpdateCustomerDetails(InitialPageDataForCustomerProfile customerData);
    }
}
