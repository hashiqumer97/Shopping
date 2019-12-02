using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;
using Shopping.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private GenericRepository<CustomerDL> customerRepository;
        private GenericRepository<OrderDL> orderRepository;
        private GenericRepository<ProductDL> productRepository;
        private GenericRepository<OrderItemDL> orderItemRepository;
        private readonly ShoppingContext context;

        public UnitOfWork(DbContext dbContext)
        {
            context = (ShoppingContext)dbContext;
        }
        public GenericRepository<CustomerDL> CustomerRepository
        {
            get
            {
                if(this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<CustomerDL>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<ProductDL> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<ProductDL>(context);
                }
                return productRepository;
            }
        }

        public GenericRepository<OrderDL> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<OrderDL>(context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<OrderItemDL> OrderItemRepository
        {
            get
            {
                if (this.orderItemRepository == null)
                {
                    this.orderItemRepository = new GenericRepository<OrderItemDL>(context);
                }
                return orderItemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
