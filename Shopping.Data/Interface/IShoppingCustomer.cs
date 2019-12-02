using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Interface
{
    public interface IShoppingCustomer
    {
        List<CustomerDL> GetCustomers();
    }
}
