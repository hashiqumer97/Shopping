using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;
using Shopping.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Data.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ShoppingContext _context;

        public OrdersRepository(ShoppingContext context)
        {
            _context = context;
        }

       

        public List<OrderDL> GetOrders()
        {
            return _context.Orders.Include(i => i.OrderLineItems).Include(o => o.Customers).OrderBy(o => o.OrderId).ToList();
        }

        public IEnumerable<OrderDL> GetOrdersById(int id , int ordid)
        {
            return  _context.Orders.Where(c => c.OrderId == id).Include((i => i.OrderLineItems.Any(i => i.OrderItemId == ordid)));  
        }

        public void AddOrder(OrderDL order)
        {
            _context.Add(order);
            _context.SaveChanges();

        }

        public void UpdateOrder(OrderDL order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
           
        }

        public void DeleteOrder(OrderDL order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void DeleteEntireOrder(OrderDL order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
