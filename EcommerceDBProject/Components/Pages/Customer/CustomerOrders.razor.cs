using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
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
        ProductReturn ProductReturn { get; set; } = new();
        ProductReview ProductReview { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForCustomerOrders(UserDetailId);
            OrdersList = InitialPageData.CustomerOrdersViewModelList;
            ProductReturn = InitialPageData.ProductReturn;
            ProductReview = InitialPageData.ProductReview;
        }

        #endregion

        #region Dialogue Box Functions

        public void OpenReturnDialog(CustomerOrdersViewModel orderItem)
        {
            ProductReturn.OrderItemId = orderItem.OrderItemId;
            InitialPageData.OrderQuantityForReturn = orderItem.OrderQuantity;
            InitialPageData.ShowReturnDialogBox = true;

        }

        public void OpenReviewDialog(CustomerOrdersViewModel orderItem)
        {
            ProductReview.OrderItemId = orderItem.OrderItemId;
            InitialPageData.ShowReviewDialogBox = true;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        public void CloseDialog()
        {
            InitialPageData.ShowReturnDialogBox = false;
            InitialPageData.ShowReviewDialogBox = false;
        }

        #endregion

        #region Confirm Return Function

        public void ConfirmReturn()
        {
            if(string.IsNullOrEmpty(ProductReturn.ReturnReason))
            {
                toastService.ShowError("Enter Return Reason");
            }
            else if(ProductReturn.Quantity <= 0)
            {
                toastService.ShowError("Enter Return quantity");
            }
            else if(ProductReturn.Quantity > InitialPageData.OrderQuantityForReturn)
            {
                toastService.ShowError("Return Quantity must be less than order Quantity");
            }
            else
            {
                ProductReturn.ReturnDate = DateTime.Now;
                ProductReturn.ReturnStatus = "Pending";
                ReturnReviewService.AddReturn(ProductReturn);
                toastService.ShowSuccess("Request for return added Successfully");
                InitialPageData.ProductReturn = new();
                InitialPageData.ShowReturnDialogBox = false;
            }
        }
        
        public void AddCustomerReview()
        {
            if(ProductReview.Rating < 0 )
            {
                toastService.ShowError("Please Rate the Product from 0-5");
            }
            else
            {
                ProductReview.ReviewDate = DateTime.Now;
                ReturnReviewService.AddReview(ProductReview);
                toastService.ShowSuccess("Review added Successfully");
                InitialPageData.ProductReview = new();
                InitialPageData.ShowReviewDialogBox = false;
            }
        }
        
        #endregion
    }
}
