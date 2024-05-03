using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerInventoryItems: ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] IUserInterface UserService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForSellerInventoryItems InitialPageData { get; set; } = new();
        List<InventoryItem> InventoryItemsList { get; set; } = new();
        List<ProductCategory> ProductCategories { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForSellerInventoryItems(UserDetailId);
            InventoryItemsList = InitialPageData.SellerInventoryItems;
            ProductCategories = InitialPageData.ProductCategories;
        }

        #endregion

        #region OnChange Functions

        protected void OnProductCategoryChanged(ChangeEventArgs e)
        {
            var productCategory = ProductService.GetProductCategoryByCategoryId(e.Value.ToString());

            if (productCategory == null)
            {
                InventoryItemsList = InventoryItemService.GetSellerInventoryItemsListFromSellerId(InitialPageData.Seller.SellerId);
            }
            else
            {
                InventoryItemsList = InventoryItemService.GetSellerInventoryItemsOfSpecifcCetagory(productCategory.CategoryId, InitialPageData.Seller.SellerId);
            }
        }

        #endregion

        #region OnClick Functions

        protected void OnInventoryItemDeleteClick(InventoryItem inventoryItem)
        {
            
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
