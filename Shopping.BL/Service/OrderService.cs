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

        public void DeleteOrder(OrderBL orders)
        {          
            var order = shoppingContext.Orders.Include(a => a.Products).FirstOrDefault(o => o.OrderId == orders.OrderId);
            var orderLineItem = order.Products.FirstOrDefault(f => f.OrderItemId == orders.OrderItemId);
            unitOfWork.OrderItemRepository.Delete(orderLineItem);
            unitOfWork.Save();
        }

        public OrderBL GetOrderById(int id)
        {
        return mapper.Map<OrderBL>(ordersRepository.GetOrders().Where(i => i.OrderId == id).FirstOrDefault());
        }

        
            

        public void UpdateOrder(OrderBL ord)
        {
            var order = shoppingContext.Orders.Include(a => a.Products).FirstOrDefault(o => o.OrderId == ord.OrderId);
            var orderLineItem = order.Products.FirstOrDefault(f => f.OrderItemId == ord.OrderItemId);
            
                orderLineItem.OrderitemDate = ord.ProductOrderDate;
                orderLineItem.OrderitemQuantity = ord.ProductQuantity;
                orderLineItem.OrderitemProductPrice = ord.ProductPrice;
                unitOfWork.OrderItemRepository.Update(orderLineItem);
                unitOfWork.Save();
            
            
        }

       
    }
}
