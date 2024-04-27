using EcommerceDBProject.NewF;

namespace EcommerceDBProject.Services.Interface
{
    public interface IInventoryItemInterface
    {
        List<InventoryItem> GetAllInventoryItemsList();
        List<InventoryItem> GetAllInventoryItemsOfSpecifcCetagory(string categoryId);
    }
}
