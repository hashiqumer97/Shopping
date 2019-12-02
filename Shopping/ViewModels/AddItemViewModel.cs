using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class AddItemViewModel
    {
        public int OrderItemId { get; set; }
        public string CustomerName { get; set; }
        public string Date { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductPrice { get; set; }
    }
}
