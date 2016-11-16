using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    class BrancheRepository : IbranchRepositoryl, IDisposable
    {
        private StoreEntities _context;

        public BrancheRepository()
        {
            _context = new StoreEntities();
        }

       
        //public BrancheRepository()
        //{
        //    _context = new StoreEntities();
        //}
        public void DeleteBranch(int branchId)
        {
            Branch branch =  _context.Branches.Find(branchId);
            _context.Branches.Remove(branch);
            Save();
        }

        public Branch GetBranchByID(int branchId)
        {
            return _context.Branches.Find(branchId);
        }

        public IEnumerable<Branch> GetBranches()
        {
            return _context.Branches.ToList();
        }

        public void InsertBranch(Branch branch)
        {
            _context.Branches.Add(branch);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateBranch(Branch branch)
        {
            _context.Entry(branch).State = EntityState.Modified;
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
        // ~BrancheRepository() {
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
