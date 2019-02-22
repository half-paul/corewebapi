using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using corewebapp.Models;

namespace corewebapp.Services
{
    public interface IInventoryService
    {
        InventoryItem AddInventoryItem(InventoryItem item);

        Dictionary<string, InventoryItem> GetInventoryItems();
    }
}