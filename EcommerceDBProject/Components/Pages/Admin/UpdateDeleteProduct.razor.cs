using Blazored.Toast.Services;
using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class UpdateDeleteProduct : ComponentBase
    {
        #region Injections

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        InitialPageDataForUpdateDeleteProduct InitialPageData { get; set; } = new();
        List<ProductViewModel> Products { get; set; } = new();
        List<ProductCategory> CategoriesList { get; set; } = new();
        List<Supplier> SuppliersList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForUpdateDeleteProduct();
            Products = InitialPageData.Products;
            CategoriesList = InitialPageData.CategoriesList;
            SuppliersList = InitialPageData.SuppliersList;
        }

        #endregion

        #region OnClick Functions

        protected void DeleteProduct(ProductViewModel product)
        {
            ProductService.DeleteProduct(product.Product);
            ToastService.ShowSuccess("Product Deleted Successfully");
        }

        protected void EditProduct()
        {
            InitialPageData.SelectedProduct.Product.CategoryId = InitialPageData.SelectedProductCategoryId;
            InitialPageData.SelectedProduct.Product.SupplierId = InitialPageData.SelectedSupplierId;
            ProductService.UpdateProduct(InitialPageData.SelectedProduct.Product);
            InitialPageData.IsEditDialogBoxOpen = false;
            ToastService.ShowSuccess("Product Updated Successfully");
        }

        #endregion

        #region Dialogue Box Functions

        protected void OpenEditProductDialogBox(ProductViewModel product)
        {
            InitialPageData.SelectedSupplierId = product.Supplier != null ? product.Supplier.SupplierId : "no-select";
            InitialPageData.SelectedProductCategoryId = product.Category.CategoryId;
            InitialPageData.SelectedProduct = product;
            InitialPageData.IsEditDialogBoxOpen = true;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion

        #region OnChange Functions

        protected void OnSupplierChanged(ChangeEventArgs e)
        {
            if(e.Value.ToString() == "no-select")
            {
                InitialPageData.SelectedProduct.Supplier = null;
            }
            else
            {
                InitialPageData.SelectedProduct.Supplier = ProductService.GetSupplierBySupplierId(e.Value.ToString());
            }
        }

        protected void OnCategoryChanged(ChangeEventArgs e)
        {
            InitialPageData.SelectedProduct.Category = ProductService.GetProductCategoryByCategoryId(e.Value.ToString());
        }

        #endregion
    }
}
