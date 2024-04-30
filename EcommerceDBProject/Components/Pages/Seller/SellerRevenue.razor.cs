using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Seller
{
    public partial class SellerRevenue : ComponentBase
    {
        #region Injection

        [Inject] IProductInterface ProductService { get; set; }
        [Inject] IInventoryItemInterface InventoryItemService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties
        [Parameter] public string UserDetailId { get; set; }
        List<ProductCategory> ProductCategoriesList { get; set; } = new();
        List<InventoryItem> InventoryItemList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            ProductCategoriesList = ProductService.GetAllProductCategories();
            InventoryItemList = InventoryItemService.GetSellerInventoryItemsListFromSellerId(UserDetailId);
        }

        #endregion

        #region OnClick Functons

        public class SalesInfo
        {
            public string Month { get; set; }
            public double SalesValue { get; set; }
        }
        public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 28 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 },
        new SalesInfo { Month = "Aug", SalesValue = 55 },
        new SalesInfo { Month = "Sep", SalesValue = 38 },
        new SalesInfo { Month = "Oct", SalesValue = 30 },
        new SalesInfo { Month = "Nov", SalesValue = 25 },
        new SalesInfo { Month = "Dec", SalesValue = 32 }
    };
        #endregion

        #region OnChange Functions

        //protected void OnProductCategoryChanged(ChangeEventArgs e)
        //{
        //    if (e.Value.ToString() != "no-select")
        //    {
        //        Product.CategoryId = e.Value.ToString();
        //    }
        //}

        //protected void OnSupplierChanged(ChangeEventArgs e)
        //{
        //    if (e.Value.ToString() != "no-select")
        //    {
        //        Product.SupplierId = e.Value.ToString();
        //    }
        //}

        #endregion
    }
}
