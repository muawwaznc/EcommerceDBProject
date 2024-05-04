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

        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] IUserInterface UserService { get; set; }
        [Inject] IToastService toastService { get; set; }
        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        List<Product> ProductList { get; set; } = new();
        List<ProductCategory> ProductCategories { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public int SalePrice { get; set; }
        public string Condition { get; set; }
        public bool Visibility { get; set; }

        #endregion
        #region Load Initials

        protected override void OnInitialized()
        {
            ProductCategories = ProductService.GetAllProductCategories();
        }

        #endregion

        
        #region BuyProducts
        public void BuyProducts()
        {
            InventoryItem inventory = new();
            inventory.ProductId = ProductId;
            inventory.Seller = UserService.GetSellerFromUserDetailId(UserDetailId);
            inventory.SalePrice = SalePrice;
            inventory.Condition = Condition;
            InventoryItemService.AddInventoryItem(inventory);
            toastService.ShowSuccess("Product bought successfully");
        }

        #endregion
        #region OnChange
        protected void OnProductCategoryChanged(ChangeEventArgs e)
        {
            var productCategory = ProductService.GetProductCategoryByCategoryId(e.Value.ToString());

            if (productCategory == null)
            {
                ProductList = ProductService.GetAllProducts();
            }
            else
            {
                ProductList = ProductService.GetAllProductsByCategoryId(productCategory.CategoryId);
            }
        }
        #endregion
        #region DialogFunction
        public void OpenDialog(string productId)
        {
            ProductId = productId;
            Visibility = true;
        }
        public void CloseDialog()
        {
            Visibility = false;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }
        #endregion
    }
}
