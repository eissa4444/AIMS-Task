using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class WarehouseRepository : IwarehouseRepository, IDisposable
    {
        private StoreEntities _context;

        public WarehouseRepository()
        {
            _context = new StoreEntities();
        }

        public void DeleteWarehouse(int warehouseId)
        {
            Warehouse warehouse = _context.WareHouses.Find(warehouseId);
            _context.WareHouses.Remove(warehouse);
            Save();
        }

        public Warehouse GetWarehouseById(int warehouseId)
        {
            Warehouse warehouse = _context.WareHouses.Find(warehouseId);
            return warehouse;
        }

        public IEnumerable<Warehouse> GetWarehouses()
        {
            return _context.WareHouses.ToList();
        }

        public void InsertWarehouse(Warehouse warehouse)
        {
            _context.WareHouses.Add(warehouse);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            _context.Entry(warehouse).State = EntityState.Modified;
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
        // ~WarehouseRepository() {
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
