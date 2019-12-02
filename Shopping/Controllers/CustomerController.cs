using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping.BL.Interface;
using Shopping.BL.Service;
using Shopping.ViewModels;
using Shopping.Views.Entities;

namespace Shopping.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var cust = _customerService.GetCustomers();
            var customers = _mapper.Map<IEnumerable<CustomerPL>>(cust);
            return View(customers);
        }

        
    }
}