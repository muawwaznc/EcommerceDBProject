using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerOrders : ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] ISellerInterface SellerService { get; set; }
        [Inject] IOrderInterface OrderService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForSellerOrders InitialPageData { get; set; } = new();
        List<SellerOrdersViewModel> OrdersList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForSellerOrders(UserDetailId);
            OrdersList = InitialPageData.SellerOrdersViewModelList;
        }

        #endregion

        #region Dialogue Box Functions

        protected void OpenConfirmOrderModel()
        {

        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion

        #region ShipOrder Functions

        protected void ShipOrder(SellerOrdersViewModel orderItemViewModel)
        {
            OrderService.ShipOrder(orderItemViewModel.OrderItemId);
            orderItemViewModel.IsCompleteOrderButtonDisabled = true;
            //ToastService.ShowMessage("Order Shipped Successfully");
        }

        #endregion
    }
}
