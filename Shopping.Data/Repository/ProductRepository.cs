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
    public class ProductRepository : IShoppingProduct
    {
        private readonly ShoppingContext context;

        public ProductRepository(ShoppingContext context)
        {
            this.context = context;
        }

        public List<ProductDL> GetProducts()
        {
            return context.Products.OrderBy(p => p.ProductName).ToList();
        }

        public async Task<ProductDL> GetProductById(int id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<ProductDL> GetProductByName(string name)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductName == name);
        }
    }
}
