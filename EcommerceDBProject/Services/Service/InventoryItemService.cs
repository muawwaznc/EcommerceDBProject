using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using System;

namespace EcommerceDBProject.Services.Service
{
    public class InventoryItemService : IInventoryItemInterface
    {
        public List<InventoryItem> GetAllInventoryItemsList()
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var inventoryItemList = db.InventoryItems.ToList();
                return inventoryItemList;
            }            
        }

        public List<InventoryItem> GetAllInventoryItemsOfSpecifcCetagory(string categoryId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var inventoryItems = db.InventoryItems
                   .Where(x => x.Product.CategoryId == categoryId)
                   .ToList();

                return inventoryItems;
            }
        }
    
        public InventoryItem GetInventoryItemFromInventoryItemId(string inventoryItemId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var inventoryItem = db.InventoryItems.FirstOrDefault(x => x.InventoryItemId == inventoryItemId);
                return inventoryItem;
            }
        }
    }
}
