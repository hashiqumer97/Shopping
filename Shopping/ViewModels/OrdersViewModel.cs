using Shopping.BL;
using Shopping.Data.Entities;
using Shopping.Views.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class OrdersViewModel
    {
        public int OrderId { get; set; }
        public string ProductOrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemsViewModel> Products { get; set; }

    }
}
