using Shopping.Data.Entities;
using Shopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Interface
{
    public interface IUnitOfWork
    {
        GenericRepository<CustomerDL> CustomerRepository { get; }
        GenericRepository<ProductDL> ProductRepository { get; }
        GenericRepository<OrderDL> OrderRepository { get; }
        GenericRepository<OrderItemDL> OrderItemRepository { get; }

        void Save();
    }
}
