using Blazored.Toast.Services;
using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class AddCategory
    {
        #region Injection

        [Inject] IProductInterface ProductService { get; set; }

        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        protected ProductCategory ProductCategory { get; set; } = new();

        #endregion

        #region OnClick Functions

        protected void AddProductCategory()
        {
            if(ProductCategory.CategoryName == null)
            {
                ToastService.ShowError("Enter Category name");
            }
            else if(ProductCategory.CategoryDescription == null)
            {
                ToastService.ShowError("Enter Category Description");
            }
            else
            {
                if (!ProductService.IsCategoryNameAlreadyExist(ProductCategory.CategoryName))
                {
                    ProductService.AddProductCategory(ProductCategory);
                    ToastService.ShowSuccess("Category Added Succesfully");
                }
                else
                {
                    ToastService.ShowError("Duplication Of Category Name");
                }
            }
        }

        #endregion
    }
}
