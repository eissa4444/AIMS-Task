using BOL;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IwarehouseRepository : IDisposable
    {
        IEnumerable<Warehouse> GetWarehouses();
        Warehouse GetWarehouseById(int warehouseId);
        void InsertWarehouse(Warehouse warehouse);
        void DeleteWarehouse(int warehouseId);
        void UpdateWarehouse(Warehouse warehouse);
        void Save();
    }
}
