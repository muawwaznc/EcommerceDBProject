using EcommerceDBProject.DBContext;
using EcommerceDBProject.Services.Interface;
using System;

namespace EcommerceDBProject.Services.Service
{
    public class InventoryItemService : IInventoryItemInterface
    {
        public List<InventoryItem> GetAllInventoryItemsList()
        {
            using (var db = new EcommerceDbContext())
            {
                var inventoryItemList = db.InventoryItems.ToList();
                return inventoryItemList;
            }            
        }

        public List<InventoryItem> GetAllInventoryItemsOfSpecifcCetagory(string categoryId)
        {
            using (var db = new EcommerceDbContext())
            {
                var inventoryItems = db.InventoryItems
                   .Where(x => x.Product.CategoryId == categoryId)
                   .ToList();

                return inventoryItems;
            }
        }
    
        public InventoryItem GetInventoryItemFromInventoryItemId(string inventoryItemId)
        {
            using(var db = new EcommerceDbContext())
            {
                var inventoryItem = db.InventoryItems.FirstOrDefault(x => x.InventoryItemId == inventoryItemId);
                return inventoryItem;
            }
        }

        public List<InventoryItem> GetSellerInventoryItemsListFromSellerId(string sellerId)
        {
            using(var db = new EcommerceDbContext())
            {
                var inventoryItemsList = db.InventoryItems.Where(x => x.SellerId == sellerId).ToList();
                return inventoryItemsList;
            }
        }

        public List<InventoryItem> GetSellerInventoryItemsOfSpecifcCetagory(string categoryId, string sellerId)
        {
            using (var db = new EcommerceDbContext())
            {
                var inventoryItems = db.InventoryItems
                   .Where(x => x.Product.CategoryId == categoryId && x.SellerId == sellerId)
                   .ToList();

                return inventoryItems;
            }
        }
        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            using (var db = new EcommerceDbContext())
            {
                db.InventoryItems.Add(inventoryItem);
                db.SaveChanges();
            }
        }
    }
}
