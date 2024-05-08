using Blazored.Toast.Services;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class ReturnOrder : ComponentBase
    {
        #region Injection

        [Inject] IOrderInterface OrderService { get; set; }
        [Inject] IOrderReturnReviewInterface ReturnReviewService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        List<SellerReturnsViewModel> sellerReturnList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            sellerReturnList = ReturnReviewService.GetSellerReturns(UserDetailId);
        }

        #endregion

        #region Return Functions

        public void CompleteReturn(string productReturnId)
        {
            ReturnReviewService.UpdateProductReturn(productReturnId);
            ToastService.ShowSuccess("Returned Request Cancelled successfully");
        }

        public void RejectReturn(string productReturnId)
        {
            ReturnReviewService.RejectReturnRequest(productReturnId);
        }

        #endregion
    }
}
