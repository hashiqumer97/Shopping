using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data
{
    public class ShoppingContext : IdentityDbContext
    {
        //public readonly object ProductName;

        // private readonly IConfiguration config;

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {

        }

        public DbSet<ProductDL> Products { get; set; }
        public DbSet<OrderDL> Orders { get; set; }
        public DbSet<OrderItemDL> OrderItems { get; set; }
        public DbSet<CustomerDL> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductDL>()
            .HasData(new
            {
                ProductId = 1,
                ProductName = "Shampoo",
                ProductDescription = "Put it on your head and rub it!",
                Quantity = 150,
                UnitPrice = 100
            },
                new
                {
                    ProductId = 2,
                    ProductName = "Milk Powder",
                    ProductDescription = "Used to make tea and coffee.",
                    Quantity = 100,
                    UnitPrice = 200
                });

            builder.Entity<CustomerDL>()
            .HasData(new
            {
                CustomerId = 1,
                CustomerName = "John Silva",
                Address = "256, Galle Road, Colombo 06",
                ContactNumber = "0765763465"
            },
            new
            {
                CustomerId = 2,
                CustomerName = "Peter Parker",
                Address = "256, Kandy Road, Kandy",
                ContactNumber = "0774653354"

            });
            builder.Entity<OrderDL>()
            .HasData(new
            {
                OrderId = 1,
                OrderDate = "2019-11-11",
                CustomerId = 1
            });
            //builder.Entity<OrderItemDL>().HasOne(i => i.Order).WithMany(o => o.OrderItems);

        }
    }
}
