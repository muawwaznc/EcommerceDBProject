using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerBuyProducts : ComponentBase
    {
        #region Injection

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] IUserInterface UserService { get; set; }
        [Inject] IToastService toastService { get; set; }

        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        InitialPageDataForSellerBuyProducts InitialPageData { get; set; } = new();
        BuyProductViewModel BuyProductViewModel { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitaialPageDataForSellerBuyProducts();
            BuyProductViewModel = InitialPageData.BuyProductViewModel;
        }

        #endregion
        
        #region BuyProducts

        public void BuyProducts()
        {
            InventoryItem inventory = new();
            inventory.ProductId = BuyProductViewModel.ProductId;
            inventory.SellerId = UserService.GetSellerFromUserDetailId(UserDetailId).SellerId;
            inventory.SalePrice = BuyProductViewModel.SalePrice;
            inventory.Condition = BuyProductViewModel.Condition;
            inventory.StockAmount = BuyProductViewModel.Quantity;
            InventoryItemService.AddInventoryItem(inventory);
            CloseDialog();
            toastService.ShowSuccess("Product bought successfully");
        }

        #endregion

        #region OnChange Functions

        protected void OnProductCategoryChanged(ChangeEventArgs e)
        {
            if(e.Value.ToString() == "no-select")
            {
                InitialPageData.ProductList = ProductService.GetProductViewModelList();
            }
            else
            {
                InitialPageData.ProductList = (ProductService.GetProductViewModelList()).Where(x => x.Product.CategoryId == e.Value.ToString()).ToList();
            }
        }

        #endregion

        #region DialogFunction

        public void OpenBuyProductDialogBox(string productId)
        {
            BuyProductViewModel.ProductId = productId;
            InitialPageData.BuyProductDialogBoxOpen = true;
        }

        public void CloseDialog()
        {
            InitialPageData.BuyProductDialogBoxOpen = false;
            BuyProductViewModel = new();
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion
    }
}
