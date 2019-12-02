using Shopping.BL;
using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Views.Entities
{
    public class OrderPL
    {
        [Key]
        public int OrderId { get; set; }

        public string ProductOrderDate { get; set; }
        public List<OrderItemPL> Products { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]

        public CustomerPL Customers { get; set; }
    }
}
