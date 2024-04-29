using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IOrderReturnReviewInterface
    {
        bool IsReturnAvailable(string orderItemId);
        bool IsReviewAvailable(string orderItemId);
        List<CustomerReviewsViewModel> GetCustomerReviewsViewModelListFromUserDetailId(string userDetailId);
        List<CustomerReturnsViewModel> GetCustomerReturnsViewModelListFromUserDetailId(string userDetailId);
    }
}
