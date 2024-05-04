using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerPromotion
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IProductInterface ProductService { get;set; }
        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IPromotionInterface PromotionService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForSellerPromotion InitialPageData { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForSellerPromotion(UserDetailId);
        }

        #endregion

        #region Dialog Box Functions

        protected void OpenApplyPromotionDialogBox(Promotion promotion)
        {
            InitialPageData.SelectedPromotionId = promotion.PromotionId;
            InitialPageData.ApplyPromotionDialogBox = true;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion

        #region OnChange Function

        protected void OnProductCategoryChanged(ChangeEventArgs e)
        {
            if (e.Value.ToString() != "no-select")
            {
                InitialPageData.SelectedCategoryId = e.Value.ToString();
                InitialPageData.InventoryItemsList = InventoryItemService.GetSellerInventoryItemsOfSpecifcCetagory(e.Value.ToString(), InitialPageData.SellerId);
            }
            else
            {
                InitialPageData.InventoryItemsList = InventoryItemService.GetSellerInventoryItemsListFromSellerId(InitialPageData.SellerId);
                InitialPageData.SelectedCategoryId = null;
            }
        }

        protected void OnInventoryItemChanged(ChangeEventArgs e)
        {
            if (e.Value.ToString() != "no-select")
            {
                InitialPageData.SelectedInventoryItemId = e.Value.ToString();
            }
            else 
            {
                InitialPageData.SelectedInventoryItemId = null;
            }
        }

        #endregion

        #region OnClick Functions

        protected void ApplyPromotionOnProduct()
        {
            if(InitialPageData.SelectedPromotionId != null && InitialPageData.SelectedInventoryItemId != null)
            {
                var productPromotion = new ProductPromotion{
                    PromotionId = InitialPageData.SelectedPromotionId,
                    InventoryItemId = InitialPageData.SelectedInventoryItemId
                };
                if (PromotionService.AddProductPromotion(productPromotion))
                {
                    ToastService.ShowSuccess("Promotion Is Applied Successfully");
                }
                else
                {
                    ToastService.ShowSuccess("This Promotion Is Already Applied On This Product");
                }
                InitialPageData.ApplyPromotionDialogBox = false;
            }

        }

        #endregion
    }
}
