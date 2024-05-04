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
            DatabaseService.ConvertAddressExcelToSQL(filePath + "Addresses.xlsx");
        }

        protected void OnUserDetailButtonClick()
        {
            DatabaseService.ConvertUserDetailExcelToSQL(filePath + "UserDetails.xlsx");
        }

        protected void OnSupplierButtonClick()
        {
            DatabaseService.ConvertSupplierExcelToSQL(filePath + "Suppliers.xlsx");
        }

        protected void OnCustomerButtonClick()
        {
            DatabaseService.ConvertCustomerExcelToSQL(filePath + "Customers.xlsx");
        }

        protected void OnSellerButtonClick()
        {
            DatabaseService.ConvertSellerExcelToSQL(filePath + "Sellers.xlsx");
        }

        protected void OnProductButtonClick()
        {
            DatabaseService.ConvertProductExcelToSQL(filePath + "Products.xlsx");
        }

        protected void OnPromotionButtonClick()
        {

        }

        protected void OnInventoryItemButtonClick()
        {
            DatabaseService.GenerateRandomInventoryItems();
        }

        protected void OnOrderButtonClick()
        {
            DatabaseService.GenerateRandomInventoryItems();
        }

        #endregion
    }
}
