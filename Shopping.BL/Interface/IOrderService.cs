using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL.Interface
{
    public interface IOrderService
    {

        List<OrderBL> GetOrders();
        OrderBL GetOrderById(int id);
        void CreateOrder(OrderBL order);
        void DeleteEntireOrder(OrderBL orders);
        void ChangeOrder(OrderBL orderBO);



    }
}
