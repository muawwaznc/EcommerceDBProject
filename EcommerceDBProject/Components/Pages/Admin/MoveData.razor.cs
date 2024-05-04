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
        [Inject] IToastService ToastService { get; set; }

        #endregion

        #region Properties

        private static readonly string filePath = "E:\\UET\\Semester4\\DB\\Projects Files\\Excel Files\\After Cleaning\\";

        #endregion

        #region OnClick Functions

        protected void OnProductCategoryButtonClick()
        {
            DatabaseService.ConvertCategoryExcelToSQL(filePath + "ProductCategories.xlsx");
            ToastService.ShowSuccess("Product Categories Moved Successfully");
        }

        protected void OnAddressButtonClick()
        {
            DatabaseService.ConvertAddressExcelToSQL(filePath + "Addresses.xlsx");
            ToastService.ShowSuccess("Addresses Moved Successfully");
        }

        protected void OnUserDetailButtonClick()
        {
            DatabaseService.ConvertUserDetailExcelToSQL(filePath + "UserDetails.xlsx");
            ToastService.ShowSuccess("User Details Moved Successfully");
        }

        protected void OnSupplierButtonClick()
        {
            DatabaseService.ConvertSupplierExcelToSQL(filePath + "Suppliers.xlsx");
            ToastService.ShowSuccess("Suppliers Moved Successfully");
        }

        protected void OnCustomerButtonClick()
        {
            DatabaseService.ConvertCustomerExcelToSQL(filePath + "Customers.xlsx");
            ToastService.ShowSuccess("Customers Moved Successfully");
        }

        protected void OnSellerButtonClick()
        {
            DatabaseService.ConvertSellerExcelToSQL(filePath + "Sellers.xlsx");
            ToastService.ShowSuccess("Sellers Moved Successfully");
        }

        protected void OnProductButtonClick()
        {
            DatabaseService.ConvertProductExcelToSQL(filePath + "Products.xlsx");
            ToastService.ShowSuccess("Products Moved Successfully");
        }

        protected void OnPromotionButtonClick()
        {
            DatabaseService.ConvertPromotionExcelToSQL(filePath + "Promotions.xlsx");
            ToastService.ShowSuccess("Promotions Moved Successfully");
        }

        protected void OnInventoryItemButtonClick()
        {
            DatabaseService.GenerateRandomInventoryItems();
            ToastService.ShowSuccess("Inventory Items Generated Successfully");
        }

        protected void OnOrderButtonClick()
        {
            DatabaseService.GenerateRandomOrders();
            ToastService.ShowSuccess("Orders Generated Successfully");
        }

        protected void OnProductPromotionButtonClick()
        {
            DatabaseService.GenerateProductPromotions();
            ToastService.ShowSuccess("Product Promotions Generated Successfully");
        }

        protected void OnProductReturnButtonClick()
        {
            ToastService.ShowInfo("Loading....");
            DatabaseService.GenerateProductReturns();
            ToastService.ShowSuccess("Product Returns Generated Successfully");
        }

        protected void OnProductReviewButtonClick()
        {
            ToastService.ShowInfo("Loading....");
            DatabaseService.GenerateProductReviews();
            ToastService.ShowSuccess("Product Reviews Generated Successfully");
        }

        #endregion
    }
}
