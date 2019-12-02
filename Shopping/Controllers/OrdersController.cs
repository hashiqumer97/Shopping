using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.BL;
using Shopping.BL.Interface;
using Shopping.BL.Service;
using Shopping.Data.Entities;
using Shopping.ViewModels;
using Shopping.Views.Entities;

namespace Shopping.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IOrderService orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            this.mapper = mapper;
            this.orderService = orderService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Orders()
        {
            var model = mapper.Map<IEnumerable<OrdersViewModel>>(orderService.GetOrders());
            return View(model);
        }

        public IActionResult GetOrdersById(int id)
        {
            var result =  orderService.GetOrderById(id);
            return Json(result);
        }
        [HttpGet]
        [Authorize]
        public IActionResult OrderItems(int ordid)
        {
            var model = orderService.GetOrderById(ordid);
            return View(mapper.Map<OrdersViewModel>(model));
        }
        
        [HttpPost]
        public ActionResult EditOrders([FromBody]OrderViewModel orderViewModel)
        {
            orderService.UpdateOrder(mapper.Map<OrderBL>(orderViewModel));
            return RedirectToAction("AddCart", "AddCart");
        }

        

        [HttpPost]
        public ActionResult DeleteOrders([FromBody]OrdersViewModel ordersViewModel)
        {

            var order = mapper.Map<OrderBL>(ordersViewModel);
            orderService.DeleteEntireOrder(order);

            return View(order);
        }

        [HttpPost]
        public ActionResult DeleteOrder([FromBody]OrderViewModel orderViewModel)
        {
            var order = mapper.Map<OrderBL>(orderViewModel);
            orderService.DeleteOrder(order);

            return View(order);
        }

    }
        
}
