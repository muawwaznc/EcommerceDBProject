using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class UpdateDeletePromotion : ComponentBase
    {
        #region Injections

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IPromotionInterface PromotionService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        InitialPageDataForUpdateDeletePromotion InitialPageData = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForUpdateDeletePromotion();
        }

        #endregion

        #region OnClick Functions

        protected void EditPromotion()
        {
            PromotionService.UpdatePromotion(InitialPageData.SelectedPromotion);
            InitialPageData.IsEditDialogBoxOpen = false;
            ToastService.ShowSuccess("Promotion Updated Successfully");
            InitialPageData = CommonService.GetInitialPageDataForUpdateDeletePromotion();
        }

        protected void DeletePromotion(Promotion promotion)
        {
            PromotionService.DeletePromotion(promotion);
            ToastService.ShowSuccess("Promotion Deleted Successfully");
            InitialPageData = CommonService.GetInitialPageDataForUpdateDeletePromotion();
        }

        #endregion

        #region Dialogue Box Functions

        protected void OpenEditPromotionDialogBox(Promotion promotion)
        {
            InitialPageData.SelectedPromotion = promotion;
            InitialPageData.IsEditDialogBoxOpen = true;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion
    }
}
