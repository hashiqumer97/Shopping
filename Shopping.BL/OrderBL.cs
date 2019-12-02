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
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductOrderDate { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public List<OrderItemBL> Products { get; set; }
        public int CustomerId { get; set; }

        public CustomerBL Customers { get; set; }
    }
}
