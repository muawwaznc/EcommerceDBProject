using Blazored.Toast.Services;
using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class AddSupplier : ComponentBase
    {
        #region Injections

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IUserInterface UserService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        InitialPageDataForAddSupplier InitialPageData { get; set; } = new();
        Address SupplierAddress { get; set; } = new();
        UserDetail SupplierDetails { get; set; } = new();
        Supplier Supplier { get; set; } = new();

        #endregion

        #region OnClick Functions

        public void AddSupplierIntoDatabase()
        {
            if (FormValidation())
            {
                UserService.AddSupplier(InitialPageData);
            }
        }

        #endregion

        #region Validation Functions

        public bool FormValidation()
        {
            if(Supplier.SupplierName == null)
            {
                ToastService.ShowError("Enter Supplier Name");
                return false;
            }
            else if (Supplier.ContactPersonName == null)
            {
                ToastService.ShowError("Enter Contact Person Name");
                return false;
            }
            else if (SupplierDetails.Email == null)
            {
                ToastService.ShowError("Enter Email");
                return false;
            }
            else if (SupplierDetails.PhoneNumber == null)
            {
                ToastService.ShowError("Enter Phone Number");
                return false;
            }
            return true;
        }

        #endregion
    }
}
