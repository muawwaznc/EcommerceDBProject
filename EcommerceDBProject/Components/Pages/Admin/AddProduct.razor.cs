using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class AddProduct
    {
        #region Injection
        public string temp { get; set; }
        [Inject] IProductInterface ProductService { get; set; }

        [Inject] IToastService ToastService { get; set; }
        #endregion
        List<ProductCategory> CategoryList = new List<ProductCategory>();
        List<Supplier> SupplierList = new List<Supplier>();
        protected override void OnInitialized()
        {
            CategoryList = ProductService.GetAllProductCategories();
            SupplierList = ProductService.GetAllSuppliers();
        }   
    }
}
