using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface ICommonInterface
    {
        InitialPageDataForCustomerDashboard GetInitialPageDataForCustomerDashboard(string userDetailId);
        InitialPageDataForCustomerOrders GetInitialPageDataForCustomerOrders(string userDetailId);
    }
}
