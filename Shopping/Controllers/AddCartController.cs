using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Nancy.Json;
using Shopping.BL;
using Shopping.BL.Interface;
using Shopping.BL.Service;
using Shopping.Data;
using Shopping.Data.Entities;
using Shopping.ListModel;
using Shopping.ViewModels;
using Shopping.Views.Entities;

namespace Shopping.Controllers
{
    [Authorize]
    public class AddCartController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService productService;
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;

        public AddCartController(IMapper mapper, IProductService productService
            , ICustomerService customerService, IOrderService orderService)
        {
            _mapper = mapper;
            this.productService = productService;
            this.customerService = customerService;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult AddCart()
        {

            AddCartViewModel model1 = new AddCartViewModel
            {
                ProductListModel = new List<SelectListItem>()
            };

            model1.SelectedProductName = _mapper.Map<List<ProductPL>>(productService.GetProducts());
            model1.SelectedCustomerName = _mapper.Map<List<CustomerPL>>(customerService.GetCustomers());
            return View(model1);

        }
        [HttpGet]
        public ActionResult CreateOrders()
        {
            var customers = customerService.GetCustomers().ToList();
            var products = productService.GetProducts().ToList();

            ViewBag.listofCustomers = customers;
            ViewBag.listofProducts = products;

            return View();
        }

        [HttpPost]
        public ActionResult CreateOrders([FromBody]OrdersViewModel ordersViewModel)
        {
            var order = _mapper.Map<OrderBL>(ordersViewModel);
            orderService.CreateOrder(order);
            return RedirectToAction("AddCart", "AddCart");
        }
    }
}