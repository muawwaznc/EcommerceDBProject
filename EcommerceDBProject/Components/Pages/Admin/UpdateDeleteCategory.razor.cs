using Blazored.Toast.Services;
using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class UpdateDeleteCategory : ComponentBase
    {
        #region Injections

        [Inject] ICommonInterface CommonService { get; set; }
        [Inject] IProductInterface ProductService { get; set; }
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        InitialPageDataForUpdateCategory InitialPageData { get; set; } = new();
        List<ProductCategory> CategoriesList { get; set; } = new();

        #endregion

        #region Load Initials

        protected override void OnInitialized()
        {
            InitialPageData = CommonService.GetInitialPageDataForUpdateCategory();
            CategoriesList = InitialPageData.CategoriesList;
        }

        #endregion

        #region OnClick Functions

        protected void EditCategory()
        {
            ProductService.UpdateProductCategory(InitialPageData.SelectedCategory);
            InitialPageData.IsEditDialogBoxOpen = false;
            ToastService.ShowSuccess("Category Updated Successfully");
        }

        protected void DeleteProductCategory(ProductCategory productCategory)
        {
            ProductService.DeleteProductCategory(productCategory);
            ToastService.ShowSuccess("Category Deleted Successfully");
        }

        #endregion

        #region Dialogue Box Functions

        protected void OpenEditCategoryDialogBox(ProductCategory productCategory)
        {
            InitialPageData.SelectedCategory = productCategory;
            InitialPageData.IsEditDialogBoxOpen = true;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion
    }
}
