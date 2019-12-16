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
            foreach (var item in order.OrderLineItems)
            {
                var prodqty = unitOfWork.ProductRepository.GetByID(item.ProductId);

                if (item.OrderitemQuantity >= 100)
                {
                    throw new InvalidOperationException("Oh Sorry! Your Order cannot be added because the quantity is over the limit!");
                }
                if (item.OrderitemQuantity == 0 || item.OrderitemQuantity.ToString() == null)
                {
                    throw new InvalidOperationException("Oh Sorry! Your order cannot be created because the quantity is not included!");
                }
                if(prodqty.Quantity <= 0)
                {
                    throw new InvalidOperationException("Quantity is over!");
                }
                else
                {
                    var ord = mapper.Map<OrderDL>(order);
                    unitOfWork.OrderRepository.Create(ord);
                    unitOfWork.Save();
                    productService.Update(item.ProductId, -(item.OrderitemQuantity));
                }
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
                var prodqty = unitOfWork.ProductRepository.GetByID(item.ProductId);

                if (item.IsDelete)
                {
                    Delete(item);
                }
                else
                {
                    if (item.OrderitemQuantity >= 100)
                    {
                        throw new InvalidOperationException("Oh Sorry! Your Order cannot be updated because the quantity is over the limit!");
                    }

                    if (item.OrderitemDate == null)
                    {
                        throw new InvalidOperationException("Please include the date!");
                    }

                    if (item.OrderitemQuantity.ToString() == null)
                    {
                        throw new InvalidOperationException("Please include the quantity of the selected orderline item!");
                    }
                    if(prodqty.Quantity <= 0)
                    {
                        throw new InvalidOperationException("Quantity is over!");
                    }
                    else
                    {
                        var tempdiff = tempordline.OrderitemQuantity - item.OrderitemQuantity;
                        tempordline.OrderitemQuantity = item.OrderitemQuantity;
                        tempordline.OrderitemDate = item.OrderitemDate;
                        tempordline.OrderitemProductPrice = item.OrderitemProductPrice;
                        var orderitem = mapper.Map<OrderItemDL>(item);
                        if (orderitem is null) continue;
                        unitOfWork.OrderItemRepository.Update(tempordline);
                        unitOfWork.Save();
                        productService.Update(item.ProductId, tempdiff);
                    }
                } 
            }
        }

        private void Delete(OrderItemBL item)
        {
            var tempordline = unitOfWork.OrderItemRepository.GetByID(item.OrderItemId);
            mapper.Map<OrderItemDL>(item);
            unitOfWork.OrderItemRepository.Delete(tempordline);
            unitOfWork.Save();
        }
        public OrderBL GetOrderById(int id)
        {
            var getord = unitOfWork.OrderRepository.Get(includeProperties: "OrderLineItems").FirstOrDefault(o => o.OrderId == id);
            return mapper.Map<OrderBL>(getord);
        }
    }
}
