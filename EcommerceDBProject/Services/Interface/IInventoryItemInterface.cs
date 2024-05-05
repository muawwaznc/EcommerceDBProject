using EcommerceDBProject.DatabaseContext;

namespace EcommerceDBProject.Services.Interface
{
    public interface IInventoryItemInterface
    {
        void AddInventoryItem(InventoryItem inventoryItem);
        List<InventoryItem> GetAllInventoryItemsList();
        List<InventoryItem> GetAllInventoryItemsOfSpecifcCetagory(string categoryId);
        InventoryItem GetInventoryItemFromInventoryItemId(string inventoryItemId);
        List<InventoryItem> GetSellerInventoryItemsListFromSellerId(string sellerId);
        List<InventoryItem> GetSellerInventoryItemsOfSpecifcCetagory(string categoryId, string sellerId);
    }
}
