using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductOrderDate { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
    }
}
