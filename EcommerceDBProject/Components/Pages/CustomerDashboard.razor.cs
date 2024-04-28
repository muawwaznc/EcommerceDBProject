using EcommerceDBProject.NewF;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;
using System.Linq;

namespace EcommerceDBProject.Components.Pages
{
    public partial class CustomerDashboard : ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] ISellerInterface SellerService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForCustomerDashboard InitialPageData { get; set; } = new();
        List<InventoryItem> InventoryItemsList { get; set; } = new();
        List<BuyInventoryItemViewModel> BuyInventoryItemList { get; set; } = new();
        List<ProductCategory> ProductCategories { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForCustomerDashboard();
            InventoryItemsList = InitialPageData.AllInventoryItems;
            BuyInventoryItemList = InitialPageData.BuyInventoryItemList;
            ProductCategories = InitialPageData.ProductCategories;
        }

        #endregion

        #region OnChange Functions

        protected void OnProductCategoryChanged(ChangeEventArgs e)
        {
            var productCategory = ProductService.GetProductCategoryFromProductCategoryId(e.Value.ToString());

            if (productCategory == null)
            {
                InventoryItemsList = InventoryItemService.GetAllInventoryItemsList();
            }
            else
            {
                InventoryItemsList = InventoryItemService.GetAllInventoryItemsOfSpecifcCetagory(productCategory.CategoryId);
            }
        }

        protected void OnSelectedInventoryItemQuantityChange(InventoryItem inventoryItem, ChangeEventArgs e)
        {
            var buyInventoryItemViewModel = BuyInventoryItemList.FirstOrDefault(item => item.InventoryItem == inventoryItem);
            var quantityToBuy = Convert.ToInt32(e.Value);
            if (buyInventoryItemViewModel != null && quantityToBuy <= inventoryItem.StockAmount)
            {
                buyInventoryItemViewModel.QuantityToBuy = quantityToBuy;
            }
        }

        protected void OnInventoryItemSelect(InventoryItem inventoryItem, ChangeEventArgs e)
        {
            if ((bool)e.Value)
            {
                var buyInventoryItemViewModel = new BuyInventoryItemViewModel
                {
                    InventoryItem = inventoryItem,
                    QuantityToBuy = 1 
                };
                BuyInventoryItemList.Add(buyInventoryItemViewModel);
            }
            else
            {
                var itemToRemove = BuyInventoryItemList.FirstOrDefault(item => item.InventoryItem == inventoryItem);
                if (itemToRemove != null)
                {
                    BuyInventoryItemList.Remove(itemToRemove);
                }
            }
        }

        protected bool IsInventoryItemCheckboxChecked(InventoryItem inventoryItem)
        {
            var buyInventoryItemViewModel = BuyInventoryItemList.FirstOrDefault(item => item.InventoryItem == inventoryItem);
            if (buyInventoryItemViewModel != null)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Confirm Order Functions

        protected void ConfirmOrder()
        {

        }

        #endregion
    }
}
