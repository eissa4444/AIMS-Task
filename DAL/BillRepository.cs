using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class BillRepository : IbillOrderRepository, IDisposable
    {
        StoreEntities _context;

        public BillRepository()
        {
            _context = new StoreEntities();
        }

        public void Deletebill(int billId)
        {
            Bill_orders bill = _context.Bill_orders.Find(billId);
            _context.Bill_orders.Remove(bill);
            Save();
        }



        public Bill_orders GetBillByID(int billId)
        {
            return _context.Bill_orders.Find(billId);
        }

        public IEnumerable<Bill_orders> GetBills()
        {
            return _context.Bill_orders.ToList();
        }

        public void InsertBill(Bill_orders bill)
        {
            _context.Bill_orders.Add(bill);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateBill(Bill_orders bill)
        {
            _context.Entry(bill).State = EntityState.Modified;
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
        // ~CategoryRepository() {
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
