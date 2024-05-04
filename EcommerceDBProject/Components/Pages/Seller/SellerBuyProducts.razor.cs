using Blazored.Toast.Services;
using EcommerceDBProject.DatabaseContext;
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
        #endregion

        #region Properties

        [Parameter] public string UserDetailId { get; set; }
        List<Product> ProductList { get; set; } = new();
        List<ProductCategory> ProductCategories { get; set; }


        #region Load Initials

        protected override void OnInitialized()
        {
            ProductCategories = ProductService.GetAllProductCategories();
        }

        #endregion

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
    }
}
