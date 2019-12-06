using Shopping.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class OrderItemsViewModel
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public string OrderitemDate { get; set; }
        public int ProductId { get; set; }
        public int OrderitemUnitPrice { get; set; }
        public int OrderitemQuantity { get; set; }
        public int OrderitemProductPrice { get; set; }
        public bool IsDelete { get; set; }


    }
}
