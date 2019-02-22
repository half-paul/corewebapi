using NUnit.Framework;
using corewebapp.Services;
using corewebapp.Models;

namespace corewebapp.Tests.Services
{
    [TestFixture]
    public class InventoryService_IsInventory
    {
        private readonly InventoryService _inventoryService;

        public InventoryService_IsInventory()
        {
            _inventoryService = new InventoryService();
        }

        [Test]
        public void AddItemToList()
        {
            InventoryItem item = new InventoryItem() {Id=3, ItemName="Item 1",Price=30.2};

             var result = _inventoryService.AddInventoryItem(item);


            Assert.IsTrue(result.Id == 3, "Id of the item should be 3");
        }

        [Test]
        public void GetItemsFromList()
        {
            InventoryItem item = new InventoryItem() {Id=4, ItemName="Item 2",Price=330.2};

             var i = _inventoryService.AddInventoryItem(item);

             var result = _inventoryService.GetInventoryItems();


            Assert.IsTrue(result.Count == 2, "Number of Items in the list should be 2");
        }

        
    }
}