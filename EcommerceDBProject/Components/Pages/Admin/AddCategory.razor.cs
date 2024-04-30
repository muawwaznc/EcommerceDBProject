using Blazored.Toast.Services;
using EcommerceDBProject.DBContext;
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
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        List<ProductCategory> CategoryList = new List<ProductCategory>();
        protected override void OnInitialized()
        {
            CategoryList = ProductService.GetAllProductCategories();
        }

        protected void AddProductCategory()
        {
            if(CategoryName == null)
            {
                ToastService.ShowError("Enter Category name");
            }
            else if(CategoryDescription == null)
            {
                ToastService.ShowError("Enter Category Description");
            }
            else
            {
                bool IsFound = false;
                if (CategoryList != null)
                {
                    foreach (var item in CategoryList)
                    {
                        if (item.CategoryName == CategoryName)
                        {
                            IsFound = true;
                        }
                    }
                }
                if (!IsFound)
                {
                    ProductCategory category = new();
                    category.CategoryName = CategoryName;
                    category.CategoryDescription = CategoryDescription;
                    category.DateCreated = DateTime.Now;
                    ProductService.AddCategory(category);
                    ToastService.ShowSuccess("Category Added Succesfully");
                }
                else
                {
                    ToastService.ShowError("Duplication Category name");
                }
            }
           
        }
    }
}
