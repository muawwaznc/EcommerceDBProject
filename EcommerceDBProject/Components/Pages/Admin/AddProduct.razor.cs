using Blazored.Toast.Services;
using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class AddProduct
    {
        #region Injection

        [Inject] IProductInterface ProductService { get; set; }
        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        InitialPageDataForAddProduct InitialPageData { get; set; } = new();
        List<ProductCategory> ProductCategoriesList { get; set; } = new();
        List<Supplier> SuppliersList { get; set; } = new();
        Product Product { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForAddProduct();
            ProductCategoriesList = InitialPageData.ProductCategoriesList;
            SuppliersList = InitialPageData.SuppliersList;
            Product = InitialPageData.Product;
        }

        #endregion

        #region OnClick Functons

        protected void AddProductInDatabase()
        {
            if(Product.ProductName == null)
            {
                ToastService.ShowError("Enter Product Name");
            }
            else if (Product.Price <= 0)
            {
                ToastService.ShowError("Enter Valid Product Price");
            }
            else if (Product.CategoryId == null)
            {
                ToastService.ShowError("Enter Product Category");
            }
            else if (Product.ProductDescription == null)
            {
                ToastService.ShowError("Enter Product Description");
            }
            else
            {
                if(Product.SupplierId == "no-select")
                {
                    Product.SupplierId = null;
                }
                if (Product.ProductWeight <= 0)
                {
                    Product.ProductWeight = null;
                }
                ProductService.AddProduct(InitialPageData.Product);
                ToastService.ShowSuccess("Product Added Successfully");
            }            
        }

        #endregion

        #region OnChange Functions

        protected void OnProductCategoryChanged(ChangeEventArgs e)
        {
            if(e.Value.ToString() != "no-select")
            {
                Product.CategoryId = e.Value.ToString();
            }
        }

        protected void OnSupplierChanged(ChangeEventArgs e)
        {
            if (e.Value.ToString() != "no-select")
            {
                Product.SupplierId = e.Value.ToString();
            }
        }

        #endregion
    }
}
