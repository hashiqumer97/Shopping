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
        private readonly IProductService productService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IProductService productService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.productService = productService;
        }
        public List<OrderBL> GetOrders()
        {
            return mapper.Map<List<OrderBL>>(unitOfWork.OrderRepository.Get());
        }
        public void CreateOrder(OrderBL order)
        {
            var ord = mapper.Map<OrderDL>(order);
            unitOfWork.OrderRepository.Create(ord);
            foreach (var item in order.OrderLineItems)
            {
                productService.Update(item.ProductId, -(item.OrderitemQuantity));
            }
        }
        public void DeleteEntireOrder(OrderBL orders)
        {
            var order = mapper.Map<OrderDL>(orders);
            unitOfWork.OrderRepository.Delete(order);
            unitOfWork.Save();
        }
        public void ChangeOrder(OrderBL items)
        {
            foreach (var item in items.OrderLineItems)
            {
                var tempordline = unitOfWork.OrderItemRepository.GetByID(item.OrderItemId);
                var tempdiff = tempordline.OrderitemQuantity - item.OrderitemQuantity;
                tempordline.OrderitemQuantity = item.OrderitemQuantity;
                if (item.IsDelete)
                {
                    var orderitem = mapper.Map<OrderItemDL>(item);
                    if (orderitem is null) continue;
                    unitOfWork.OrderItemRepository.Delete(tempordline);
                    unitOfWork.Save();
                }
                else
                {
                    var orderitem = mapper.Map<OrderItemDL>(item);

                    if (orderitem is null) continue;
                    unitOfWork.OrderItemRepository.Update(tempordline);
                    unitOfWork.Save();
                }
                productService.Update(item.ProductId, tempdiff);
            }
        }
        public OrderBL GetOrderById(int id)
        {
            var getord = unitOfWork.OrderRepository.Get(includeProperties: "OrderLineItems").FirstOrDefault(o => o.OrderId == id);
            return mapper.Map<OrderBL>(getord);
        }

     
    }
}
