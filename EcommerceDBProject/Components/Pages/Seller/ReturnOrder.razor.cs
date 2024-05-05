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
        [Inject] IToastService toastService { get; set; }
        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        List<SellerReturnsViewModel> sellerReturnList = new();

        #endregion

        #region Load Initials
        protected override void OnInitialized()
        {
            sellerReturnList = ReturnReviewService.GetSellerReturns(UserDetailId);
        }
        #endregion
        #region OtherFunction
        public void CompleteOrCancelreturn(string orderItemId,bool cancelReturn,bool completeReturn)
        {
            if(cancelReturn)
            {
                OrderService.UpdateOrderItemReturnStatus(orderItemId, false);
                ReturnReviewService.UpdateReturnSatatus(orderItemId, "Cancelled");
                toastService.ShowSuccess("Returned Request Cancelled successfully");
            }
            else
            {
                OrderService.UpdateOrderItemReturnStatus(orderItemId, true);
                ReturnReviewService.UpdateReturnSatatus(orderItemId, "Completed");
                toastService.ShowSuccess("Returned Request Completed successfully");
            }
        }
        #endregion
    }
}
