using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Customer
{
    public partial class CustomerProfile
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IUserInterface UserService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForCustomerProfile InitialPageData { get; set; } = new();
        AddressViewModel CustomerAddress { get; set; } = new();
        UserDetail CustomerDetail { get; set; } = new();
        CustomerViewModel Customer { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForCustomerProfile(UserDetailId);
            CustomerAddress = InitialPageData.Address;
            CustomerDetail = InitialPageData.UserDetail;
            Customer = InitialPageData.Customer;
        }

        #endregion

        #region OnClick Functions

        protected void OnSaveProfileClick()
        {
            UserService.UpdateCustomerDetails(InitialPageData);
            ToastService.ShowSuccess("Profile Updated Successfully");
        }

        #endregion
    }
}
