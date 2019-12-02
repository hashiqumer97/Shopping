using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping.Data.Entities
{
    public class OrderDL
    {
        [Key]
        public int OrderId { get; set; }

        public string ProductOrderDate { get; set; }
        public List<OrderItemDL> Products { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]

        public CustomerDL Customers { get; set; }

    }
}
