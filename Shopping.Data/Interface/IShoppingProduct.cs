using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Data.Interface
{
  public interface IShoppingProduct
    {
        List<ProductDL> GetProducts();

        Task<ProductDL> GetProductById(int id);

    }
}
