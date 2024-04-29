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
    }
}
