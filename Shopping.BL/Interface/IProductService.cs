using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL.Interface
{
    public interface IProductService
    {
        List<ProductBL> GetProducts();

        ProductBL GetProductSubCategories(int id);

        void Update(int productId, int quantity);
    }
}
