namespace EcommerceDBProject.Services.Interface
{
    public interface IDatabaseInterface
    {
        void ConvertCategoryExcelToSQL(string filePath);
        void ConvertAddressExcelToSQL(string filePath);
        void ConvertCustomerExcelToSQL(string filePath);
        void ConvertInventoryItemExcelToSQL(string filePath);
        void ConvertInvetoryItemPictureExcelToSQL(string filePath);
        void ConvertOrderExcelToSQL(string filePath);
        void ConvertOrderItemExcelToSQL(string filePath);
        void ConvertProductExcelToSQL(string filePath);
        void ConvertProductPromotionExcelToSQL(string filePath);
        void ConvertProductReturnExcelToSQL(string filePath);
        void ConvertProductReviewExcelToSQL(string filePath);
        void ConvertPromotionExcelToSQL(string filePath);
        void ConvertSellerExcelToSQL(string filePath);
        void ConvertSupplierExcelToSQL(string filePath);
        void ConvertUserDetailExcelToSQL(string filePath);
    }
}
