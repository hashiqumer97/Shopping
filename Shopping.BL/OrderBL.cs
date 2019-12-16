using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping.BL
{
    public class OrderBL
    {
        [Key]
        public int OrderId { get; set; }
        public string ProductOrderDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerBL Customers { get; set; }
        public List<OrderItemBL> OrderLineItems { get; set; }

        public bool IsDelete { get; set; }

    }
}
