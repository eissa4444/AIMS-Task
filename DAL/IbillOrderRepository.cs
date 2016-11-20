using BOL;
using System.Collections.Generic;

namespace DAL
{
    public interface IbillOrderRepository
    {
        IEnumerable<Bill_orders> GetBills();
        Bill_orders GetBillByID(int billId);
        void InsertBill(Bill_orders bill);
        void Deletebill(int billId);
        void UpdateBill(Bill_orders bill);
        void Save();
    }
}
