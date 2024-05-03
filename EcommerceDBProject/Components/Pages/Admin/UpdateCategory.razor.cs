using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class UpdateCategory : ComponentBase
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
            InitialPageData.SelectedCategory.CategoryId = InitialPageData.SelectedProductCategoryId;
            ProductService.UpdateCategory(InitialPageData.SelectedCategory);
            InitialPageData.IsEditDialogBoxOpen = false;
            ToastService.ShowSuccess("Category Updated Sucessfully");
        }

        #endregion

        #region Dialogue Box Functions

        protected void OpenEditCategoryDialogBox(ProductCategory category)
        {
            InitialPageData.SelectedProductCategoryId = category.CategoryId;
            InitialPageData.IsEditDialogBoxOpen = true;
        }

        protected void OnDialogOpenHandler(Syncfusion.Blazor.Popups.BeforeOpenEventArgs args)
        {
            args.MaxHeight = null;
        }

        #endregion
    }
}
