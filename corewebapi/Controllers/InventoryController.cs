using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using corewebapp.Models;
using corewebapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace corewebapi.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _services;

        public InventoryController(IInventoryService services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("AddInventoryItem")]
        public ActionResult<InventoryItem> AddInventoryItem(InventoryItem items)
        {
            var inventoryItems = _services.AddInventoryItem(items);

            if (inventoryItems == null)
                return NotFound();

            return inventoryItems; 
        }

        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string,InventoryItem>> GetInventoryItems()
        {
            var _inventoryItems = _services.GetInventoryItems();

            if (_inventoryItems.Count == 0)
            {
                return NotFound();
            }

            return _inventoryItems;
        }
    }
}