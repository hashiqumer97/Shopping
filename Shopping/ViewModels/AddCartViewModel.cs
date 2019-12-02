using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BL;
using Shopping.Data.Entities;
using Shopping.Views.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class AddCartViewModel 
    {

        public List<SelectListItem> ProductListModel { get; set; }
        public int SelectedProductId { get; set; }
        public List<CustomerPL> SelectedCustomerName { get; set; }
        public List<ProductPL> SelectedProductName { get; set; }
        public List<OrderItemPL> OrderItems { get; set; }


        public string ProductDescription { get; set; }

        [Display (Name = "")]
        public string CustomerName { get; set; }
        [Display(Name = "")]
        public string Date { get; set; }
        [Display(Name = "")]
        public string ProductName { get; set; }
        [Display(Name = "")]
        public int UnitPrice { get; set; }
        [Display(Name = "")]
        public int Quantity { get; set; }
        [Display(Name = "")]
        public int ProductPrice { get; set; }

    }
}
