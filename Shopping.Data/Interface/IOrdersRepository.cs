using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Data.Interface
{
    public interface IOrdersRepository
    {
        IEnumerable<OrderDL> GetOrdersById(int id, int ordid);
        void DeleteOrder(OrderDL order);
        void UpdateOrder(OrderDL order);
        void AddOrder(OrderDL order);
        void DeleteEntireOrder(OrderDL order);

        List<OrderDL> GetOrders();


    }
}
