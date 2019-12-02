using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL.Interface
{
    public interface ICustomerService
    {
        IEnumerable<CustomerBL> GetCustomers();
        void Create(CustomerBL customer);
    }
}
