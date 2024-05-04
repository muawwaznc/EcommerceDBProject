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
        [Inject] IOrderReturnReviewInterface ReturnService { get; set; }
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
                OrderService.UpdateOrderItemReturnStatus(OrderItemId);
                ReturnService.AddReturn(productReturn);
            }
            

        }
        #endregion
    }
}
