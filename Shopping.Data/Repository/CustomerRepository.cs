using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;
using Shopping.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Data.Repository
{
    public class CustomerRepository : IShoppingCustomer
    {
        private readonly ShoppingContext _context;

        public CustomerRepository(ShoppingContext context)
        {
            _context = context;
        }

        public List<CustomerDL> GetCustomers()
        {
            return _context.Customers.OrderBy(c => c.CustomerName).ToList();
        }

        public async Task<CustomerDL> GetCustomerById(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }
    }
}
