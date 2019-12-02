using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shopping.BL;
using Shopping.BL.Interface;
using Shopping.BL.Service;
using Shopping.ViewModels;
using Shopping.Views.Entities;

namespace Shopping.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new AddCartViewModel();

            return View(model);
        }
        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            var result =  _productService.GetProductSubCategories(id);
            return Json(result);

        }



    }


}