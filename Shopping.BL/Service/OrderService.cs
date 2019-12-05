using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.BL.Interface;
using Shopping.Data;
using Shopping.Data.Entities;
using Shopping.Data.Interface;
using Shopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ShoppingContext shoppingContext;
        private readonly OrdersRepository ordersRepository;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ShoppingContext shoppingContext, OrdersRepository ordersRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.shoppingContext = shoppingContext;
            this.ordersRepository = ordersRepository;
        }
        public List<OrderBL> GetOrders()
        {
            return mapper.Map<List<OrderBL>>(unitOfWork.OrderRepository.Get());
        }
        public void CreateOrder(OrderBL order)
        {
            var ord = mapper.Map<OrderDL>(order);
            ordersRepository.AddOrder(ord);
        }
        public void DeleteEntireOrder(OrderBL orders)
        {
            var odrBL = shoppingContext.Orders.Where(a => a.OrderId == orders.OrderId).FirstOrDefault();
            unitOfWork.OrderRepository.Delete(odrBL);
            unitOfWork.Save();

        }

        public void DeleteOrder(OrderBL ord)
        {
            var order = unitOfWork.OrderRepository.Get(includeProperties: "OrderLineItems").FirstOrDefault(o => o.OrderId == ord.OrderId);
            var ordermap = mapper.Map<OrderDL>(ord);
            foreach (var item in ord.OrderLineItems.ToList())
            {
                var orderItem = order.OrderLineItems.FirstOrDefault(o => o.OrderItemId == item.OrderItemId);
                order.OrderLineItems.Remove(orderItem);
                unitOfWork.OrderRepository.Update(order);
                unitOfWork.Save();
            }
        }

        public OrderBL GetOrderById(int id)
        {
            return mapper.Map<OrderBL>(ordersRepository.GetOrders().Where(i => i.OrderId == id).FirstOrDefault());
        }

        public void UpdateOrder(OrderBL ord)
        {
            var order = shoppingContext.Orders.Include(a => a.OrderLineItems).FirstOrDefault(o => o.OrderId == ord.OrderId);
            var orderLineItem = order.OrderLineItems.ToList();

            foreach (var item in orderLineItem)
            {
                var lineItem = ord.OrderLineItems.FirstOrDefault(f => f.OrderItemId == item.OrderItemId);
                if (lineItem is null) continue;
                item.OrderitemDate = lineItem.OrderitemDate;
                item.OrderitemQuantity = lineItem.OrderitemQuantity;
                item.OrderitemProductPrice = lineItem.OrderitemProductPrice;

            }
            unitOfWork.OrderRepository.Update(order);
            unitOfWork.Save();
        }
    }
}
