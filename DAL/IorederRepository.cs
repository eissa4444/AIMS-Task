using BOL;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IorederRepository:IDisposable
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderId);
        void InsertOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);
        void Save();
    }
    
}
