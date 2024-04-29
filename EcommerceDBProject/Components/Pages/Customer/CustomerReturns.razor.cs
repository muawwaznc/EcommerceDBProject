using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Customer
{
    public partial class CustomerReturns : ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForCustomerReturns InitialPageData { get; set; } = new();
        List<CustomerReturnsViewModel> CustomerReturnsList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForCustomerReturns(UserDetailId);
            CustomerReturnsList = InitialPageData.CustomerReturnsViewModel;
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
