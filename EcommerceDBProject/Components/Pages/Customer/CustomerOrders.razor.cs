using Blazored.Toast.Services;
using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Syncfusion.Blazor.Charts.Internal;

namespace EcommerceDBProject.Components.Pages.Customer
{
    public partial class CustomerOrders : ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] ISellerInterface SellerService { get; set; }
        [Inject] IOrderInterface OrderService { get; set; }
        [Inject] IOrderReturnReviewInterface ReturnReviewService { get; set; }
        [Inject] IToastService toastService { get; set; }
        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForCustomerOrders InitialPageData { get; set; } = new();
        List<CustomerOrdersViewModel> OrdersList { get; set; } = new();

        public bool IsDialogBoxOpen { get; set; }
        public string OrderItemId { get; set; }
        public string ReturnReason { get; set; }
        public int ReturnQuantity { get; set; }
        public int OrderQuantity { get; set; }
        public string DialogBoxTitle { get; set; } = "Review";
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForCustomerOrders(UserDetailId);
            OrdersList = InitialPageData.CustomerOrdersViewModelList;
        }

        #endregion

        #region Dialogue Box Functions

        public void OpenDialog(CustomerOrdersViewModel orderItem)
        {
            OrderItemId = orderItem.OrderItemId;
            OrderQuantity = orderItem.OrderQuantity;
            IsDialogBoxOpen = true;

        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion

        #region Confirm Return Function
        
        public void ConfirmReturn()
        {
            if(string.IsNullOrEmpty(ReturnReason))
            {
                toastService.ShowError("Enter Return Reason");
            }
            else if(ReturnQuantity <= 0)
            {
                toastService.ShowError("Enter Return quantity");
            }
            else if(ReturnQuantity > OrderQuantity)
            {
                toastService.ShowError("Return Quantity must be less than order Quantity");
            }
            else
            {
                ProductReturn productReturn = new();
                productReturn.ReturnReason = ReturnReason;
                productReturn.ReturnDate = DateTime.Now;
                productReturn.ReturnStatus = "Pending";
                productReturn.Quantity = ReturnQuantity;
                OrderService.UpdateOrderItemReturnStatus(OrderItemId,true);
                ReturnReviewService.AddReturn(productReturn);
                toastService.ShowSuccess("Request for return added Successfully");
            }
            

        }
        public void AddCustomerReview()
        {
            if(Rating < 0 )
            {
                toastService.ShowError("Please Rate the Product from 0-5");
            }
            else
            {
                ProductReview review = new();
                review.ReviewText = ReviewText;
                review.ReviewDate = DateTime.Now;
                review.OrderItemId = OrderItemId;
                review.Rating = Rating;
                ReturnReviewService.AddReview(review);
                toastService.ShowSuccess("Review added Successfully");
            }
        }
        #endregion
    }
}
