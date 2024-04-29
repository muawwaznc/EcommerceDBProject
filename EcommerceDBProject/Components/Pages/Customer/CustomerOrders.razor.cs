using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

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

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForCustomerOrders InitialPageData { get; set; } = new();
        List<CustomerOrdersViewModel> OrdersList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForCustomerOrders(UserDetailId);
            OrdersList = InitialPageData.CustomerOrdersViewModelList;
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
    }
}
