using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IOrderReturnReviewInterface
    {
        bool IsReturnAvailable(string orderItemId);
        bool IsReviewAvailable(string orderItemId);
        void AddReturn(ProductReturn productReturn);
        void AddReview(ProductReview productReview);
        void UpdateReturnSatatus(string orderItemId, string returnStatus);
        List<SellerReturnsViewModel> GetSellerReturns(string userDetailId);
        List<CustomerReviewsViewModel> GetCustomerReviewsViewModelListFromUserDetailId(string userDetailId);
        List<CustomerReturnsViewModel> GetCustomerReturnsViewModelListFromUserDetailId(string userDetailId);
    }
}
