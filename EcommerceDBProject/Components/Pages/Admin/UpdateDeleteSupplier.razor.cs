using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;
using static EcommerceDBProject.ViewModels.InitialPageDataforUpdateDeleteSupplier;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class UpdateDeleteSupplier : ComponentBase
    {
        #region Injections

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IToastService ToastService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }

        #endregion

        #region Properties

        InitialPageDataforUpdateDeleteSupplier InitialPageData = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataforUpdateDeleteSupplier();
        }

        #endregion

        #region OnClick Functions

        protected void UpdateSupplier()
        {
            ProductService.UpdateSupplier(InitialPageData.SelectedSupplier);
            InitialPageData.IsEditDialogBoxOpen = false;
            //InitialPageData.SelectedSupplier = null;
            ToastService.ShowSuccess("Supplier Updated Successfully");
            //InitialPageData = CommonService.GetInitialPageDataForUpdateDeletePromotion();
        }

        protected void DeleteSupplier(SupplierInfoViewModel supplier)
        {
            
        }

        #endregion

        #region Dialogue Box Functions

        protected void OpenEditSupplierDialogBox(SupplierInfoViewModel supplier)
        {
            InitialPageData.SelectedSupplier = supplier;
            InitialPageData.IsEditDialogBoxOpen = true;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }
        
        public void CloseDialog()
        {
            InitialPageData.IsEditDialogBoxOpen = false;
        }
        
        #endregion
    }
}
