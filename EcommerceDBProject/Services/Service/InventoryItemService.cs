﻿using EcommerceDBProject.EcomDbContext;
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

        public List<InventoryItem> GetSellerInventoryItemsListFromSellerId(string sellerId)
        {
            using(var db = new EcommerceDbprojectContext())
            {
                var inventoryItemsList = db.InventoryItems.Where(x => x.SellerId == sellerId).ToList();
                return inventoryItemsList;
            }
        }

        public List<InventoryItem> GetSellerInventoryItemsOfSpecifcCetagory(string categoryId, string sellerId)
        {
            using (var db = new EcommerceDbprojectContext())
            {
                var inventoryItems = db.InventoryItems
                   .Where(x => x.Product.CategoryId == categoryId && x.SellerId == sellerId)
                   .ToList();

                return inventoryItems;
            }
        }
    }
}
