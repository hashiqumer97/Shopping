﻿using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping.BL
{
    public class OrderItemBL
    {
        [Key]
        public int OrderItemId { get; set; }
        public string OrderitemDate { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductBL ProductName { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderBL Orders { get; set; }
        public int OrderitemUnitPrice { get; set; }
        public int OrderitemQuantity { get; set; }
        public int OrderitemProductPrice { get; set; }
        public bool IsDelete { get; set; }
    }
}
