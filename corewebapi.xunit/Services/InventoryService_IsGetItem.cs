using System;
using Xunit;
using corewebapp.Services;
using corewebapp.Models;

namespace corewebapi.xunit.Services
{
    public class InventoryService_IsGetItem
    {

        private readonly InventoryService _inventoryService;

        public InventoryService_IsGetItem()
        {
            _inventoryService = new InventoryService();
        }

        [Fact]
        public void AddItemToList()
        {
            InventoryItem item = new InventoryItem() {Id=3, ItemName="Item 1",Price=30.2};

             var result = _inventoryService.AddInventoryItem(item);


            Assert.True(result.Id == 3, "Id of the item should be 3");
        }


        [Fact]
         public void GetItemsFromList()
        {
            InventoryItem item = new InventoryItem() {Id=4, ItemName="Item 2", Price=330.2};

             var i = _inventoryService.AddInventoryItem(item);

             var result = _inventoryService.GetInventoryItems();

            Assert.True(result.Count == 1, "The list should contain 1 item");
        }
    }
}
