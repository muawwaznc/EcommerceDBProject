using Blazored.Toast.Services;
using EcommerceDBProject.DatabaseContext;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.ViewModels;
using Microsoft.AspNetCore.Components;

namespace EcommerceDBProject.Components.Pages.Admin
{
    public partial class MoveData
    {
        #region Injections

        [Inject] IDatabaseInterface DatabaseService { get; set; }

        #endregion

        #region Properties

        private static readonly string filePath = "E:\\UET\\Semester4\\DB\\Projects Files\\Excel Files\\After Cleaning\\";

        #endregion

        #region OnClick Functions

        protected void OnProductCategoryButtonClick()
        {
            DatabaseService.ConvertCategoryExcelToSQL(filePath + "ProductCategories.xlsx");
        }

        protected void OnAddressButtonClick()
        {

        }

        protected void OnUserDetailButtonClick()
        {

        }

        protected void OnSupplierButtonClick()
        {

        }

        protected void OnCustomerButtonClick()
        {

        }

        protected void OnSellerButtonClick()
        {

        }

        protected void OnProductButtonClick()
        {

        }

        protected void OnPromotionButtonClick()
        {

        }

        #endregion
    }
}
