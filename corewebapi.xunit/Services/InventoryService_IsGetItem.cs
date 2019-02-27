using System;
using Xunit;
using corewebapp.Services;
using corewebapp.Models;
using System.Collections.Generic;

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


        [Theory]
         [MemberData("IsSaturdayIndex", MemberType = typeof(TestCase))]
         public void GetItemsFromList(InventoryItem item)
        {
          
             var i = _inventoryService.AddInventoryItem(item);

             var result = _inventoryService.GetInventoryItems();

            Assert.True(result.Count == 1, "The list should contain 1 item");
            Assert.Equal(item.Id, result[item.ItemName].Id);
        }

       
    }

    public class TestCase
    {
        public static readonly List<object[]> IsSaturdayTestCase = new List<object[]>
        {
            new object[]{new InventoryItem() {Id=4, ItemName="Item 2", Price=330.2}},
            new object[]{new InventoryItem() {Id=5, ItemName="Item 3", Price=3230.2}}
        };

        public static IEnumerable<object[]> IsSaturdayIndex
        {
            get
            {
                return IsSaturdayTestCase;
            }
        }
    }
}
