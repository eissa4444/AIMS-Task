using BOL;
using System;
using System.Collections.Generic;

namespace DAL
{
    interface IbranchRepositoryl : IDisposable
    {
        IEnumerable<Branch> GetBranches();
        Branch GetBranchByID(int branchId);
        void InsertBranch(Branch branch);
        void DeleteBranch(int branchId);
        void UpdateBranch(Branch branch);
        void Save();
    }
}
