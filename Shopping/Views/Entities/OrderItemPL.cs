using Shopping.Data.Entities;
using Shopping.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Views.Entities
{
    public class OrderItemPL
    {
        public int OrderId { get; set; }

        public string ProductOrderDate { get; set; }
        public List<OrderItemsViewModel> Products { get; set; }
        public int CustomerId { get; set; }

        public CustomerPL Customers { get; set; }
    }
}
