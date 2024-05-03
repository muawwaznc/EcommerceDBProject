using Blazored.Toast.Services;
using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerProfile : ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IUserInterface UserService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForSellerProfile InitialPageData { get; set; } = new();
        AddressViewModel SellerAddress { get; set; } = new();
        UserDetail SellerDetail { get; set; } = new();
        SellerViewModel Seller { get; set; } = new();

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

        #region OnClick Functions

        protected void OnSaveProfileClick()
        {
            UserService.UpdateSellerDetails(InitialPageData);
            ToastService.ShowSuccess("Profile Updated Successfully");
        }

        #endregion
    }
}
