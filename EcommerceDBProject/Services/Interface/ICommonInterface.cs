using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface ICommonInterface
    {
        InitialPageDataForCustomerDashboard GetInitialPageDataForCustomerDashboard(string userDetailId);
        InitialPageDataForCustomerOrders GetInitialPageDataForCustomerOrders(string userDetailId);
        InitialPageDataForCustomerReturns GetInitialPageDataForCustomerReturns(string userDetailId);
        InitialPageDataForCustomerReviews GetInitialPageDataForCustomerReviews(string userDetailId);
        InitialPageDataForSellerInventoryItems GetInitialPageDataForSellerInventoryItems(string userDetailId);
        InitialPageDataForSellerOrders GetInitialPageDataForSellerOrders(string userDetailId);
        InitialPageDataForSellerDashboard GetInitialPageDataForSellerDashboard(string userDetailId);
        InitialPageDataForSellerProfile GetInitialPageDataForSellerProfile(string userDetailId);
        InitialPageDataForCustomerProfile GetInitialPageDataForCustomerProfile(string userDetailId);
        InitialPageDataForAddProduct GetInitialPageDataForAddProduct();
        InitialPageDataForSellerPromotion GetInitialPageDataForSellerPromotion(string userDetailId);
        InitialPageDataForUpdateDeleteProduct GetInitialPageDataForUpdateDeleteProduct();
        InitialPageDataForUpdateCategory GetInitialPageDataForUpdateCategory();
        InitialPageDataForUpdateDeletePromotion GetInitialPageDataForUpdateDeletePromotion();
    }
}
