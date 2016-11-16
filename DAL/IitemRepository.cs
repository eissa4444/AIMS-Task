using BOL;
using System;
using System.Collections.Generic;

namespace DAL
{
    interface IitemRepository : IDisposable
    {
        IEnumerable<Item> GetItems();
        Branch GetItemByID(int itemId);
        void InsertItem(Item item);
        void DeleteItem(int itemId);
        void UpdateItem(Item item);
        void Save();
    }
}
