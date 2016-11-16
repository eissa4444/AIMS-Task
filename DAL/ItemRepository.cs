using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    class ItemRepository : IitemRepository, IDisposable
    {
        StoreEntities _context;

        public ItemRepository()
        {
            _context = new StoreEntities();
        }

        public void DeleteItem(int itemId)
        {
            Item item = _context.Items.Find(itemId);
            _context.Items.Remove(item);
            Save();
        }

        public Item GetItemByID(int itemId)
        {
            return _context.Items.Find(itemId);
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public void InsertItem(Item item)
        {
            _context.Items.Add(item);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            Save();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ItemRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
