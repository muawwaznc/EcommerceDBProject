using EcommerceDBProject.DBContext;
using EcommerceDBProject.ViewModels;

namespace EcommerceDBProject.Services.Interface
{
    public interface IOrderReturnReviewInterface
    {
        bool IsReturnAvailable(string orderItemId);
        bool IsReviewAvailable(string orderItemId);
        void AddReturn(ProductReturn productReturn);
        void AddReview(ProductReview productReview);
        void UpdateProductReturn(string returnId);
        List<SellerReturnsViewModel> GetSellerReturns(string userDetailId);
        List<CustomerReviewsViewModel> GetCustomerReviewsViewModelListFromUserDetailId(string userDetailId);
        List<CustomerReturnsViewModel> GetCustomerReturnsViewModelListFromUserDetailId(string userDetailId);
        void RejectReturnRequest(string returnId);
    }
}
