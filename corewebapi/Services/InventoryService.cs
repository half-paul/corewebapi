using System.Collections.Generic;
using corewebapp.Models;

namespace corewebapp.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Dictionary<string, InventoryItem> _inventoryItems;

        public InventoryService()
        {
            _inventoryItems = new Dictionary<string, InventoryItem>();
        }
        public InventoryItem AddInventoryItem(InventoryItem item)
        {
           _inventoryItems.Add(item.ItemName, item);
           
           return item;
        }

        public Dictionary<string, InventoryItem> GetInventoryItems()
        {
            return _inventoryItems;
        }
    }

}