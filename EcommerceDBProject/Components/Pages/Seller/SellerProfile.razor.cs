using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerProfile : ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForSellerProfile InitialPageData { get; set; } = new();
        Address SellerAddress { get; set; } = new();
        UserDetail SellerDetail { get; set; } = new();
        EcommerceDBProject.DBContext.Seller Seller { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForSellerProfile(UserDetailId);
            SellerAddress = InitialPageData.Address;
            SellerDetail = InitialPageData.UserDetail;
            Seller = InitialPageData.Seller;
        }

        #endregion

        #region Dialogue Box Functions

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion
    }
}
