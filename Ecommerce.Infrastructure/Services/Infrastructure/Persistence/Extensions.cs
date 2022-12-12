using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Utilities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Services.Infrastructure.Persistence
{
    public static class Extensions
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EcommerceDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("Ecommerce"));
                //option.EnableSensitiveDataLogging();
            });

            return services;
        }

        public static void Seed(this ModelBuilder modelBuilder) 
        {
            //modelBuilder.Entity<Category>()
            //   .HasData(
            //    new Category
            //    {
            //        Id = 1,
            //        ProductCategory = ProductCategoryEnum.Laptop,
            //        TimeCreated = DateTimeOffset.UtcNow,
            //        TimeUpdated = DateTimeOffset.UtcNow
            //    },
            //    new Category
            //    {
            //        Id = 2,
            //        ProductCategory = ProductCategoryEnum.Phone,
            //        TimeCreated = DateTimeOffset.UtcNow,
            //        TimeUpdated = DateTimeOffset.UtcNow
            //    },
            //    new Category
            //    {
            //        Id = 3,
            //        ProductCategory = ProductCategoryEnum.Shorts,
            //        TimeCreated = DateTimeOffset.UtcNow,
            //        TimeUpdated = DateTimeOffset.UtcNow
            //    },
            //    new Category
            //    {
            //        Id = 4,
            //        ProductCategory = ProductCategoryEnum.Jacket,
            //        TimeCreated = DateTimeOffset.UtcNow,
            //        TimeUpdated = DateTimeOffset.UtcNow
            //    },
            //    new Category
            //    {
            //        Id = 5,
            //        ProductCategory = ProductCategoryEnum.Shirt,
            //        TimeCreated = DateTimeOffset.UtcNow,
            //        TimeUpdated = DateTimeOffset.UtcNow
            //    },
            //    new Category
            //    {
            //        Id = 6,
            //        ProductCategory = ProductCategoryEnum.Trouser,
            //        TimeCreated = DateTimeOffset.UtcNow,
            //        TimeUpdated = DateTimeOffset.UtcNow
            //    },
            //    new Category
            //    {
            //        Id = 7,
            //        ProductCategory = ProductCategoryEnum.SweatPants,
            //        TimeCreated = DateTimeOffset.UtcNow,
            //        TimeUpdated = DateTimeOffset.UtcNow
            //    });


            modelBuilder.Entity<Product>()
                 .HasData(
                 new Product
                 {
                     Id = 1,
                     Name = "Asus",
                     Price = 250.000,
                     ProductCategory = ProductCategoryEnum.Laptop,
                     //ProductImage = "",
                     IsAvailable = true,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product 
                 {
                     Id = 2,
                     Name = "Dell",
                     Price = 350.000,
                     ProductCategory = ProductCategoryEnum.Laptop,
                     //ProductImage = "",
                     IsAvailable = true,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product
                 {
                     Id = 3,
                     Name = "MacBook",
                     Price = 550.000,
                     ProductCategory = ProductCategoryEnum.Laptop,
                     //ProductImage = "",
                     IsAvailable = false,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product
                 {
                     Id = 4,
                     Name = "IPhone11",
                     Price = 350.000,
                     ProductCategory = ProductCategoryEnum.Phone,
                     //ProductImage = "",
                     IsAvailable = false,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product
                 {
                     Id = 5,
                     Name = "Shirt",
                     Price = 60.00,
                     ProductCategory = ProductCategoryEnum.Shirt,
                     //ProductImage = "",
                     IsAvailable = true,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product
                 {
                     Id = 6,
                     Name = "Jacket",
                     Price = 35.00,
                     ProductCategory = ProductCategoryEnum.Jacket,
                     //ProductImage = "",
                     IsAvailable = false,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product
                 {
                     Id = 7,
                     Name = "Sweat Pants",
                     Price = 30.00,
                     ProductCategory = ProductCategoryEnum.SweatPants,
                     //ProductImage = "",
                     IsAvailable = true,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product
                 {
                     Id = 8,
                     Name = "Trouser",
                     Price = 25.000,
                     ProductCategory = ProductCategoryEnum.Trouser,
                     //ProductImage = "",
                     IsAvailable = true,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 },
                 new Product
                 {
                     Id = 9,
                     Name = "Shorts",
                     Price = 50.000,
                     ProductCategory = ProductCategoryEnum.Shorts,
                     //ProductImage = "",
                     IsAvailable = false,
                     TimeUpdated = DateTimeOffset.UtcNow,
                     TimeCreated = DateTimeOffset.UtcNow
                 });


            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    TrackingId = Guid.NewGuid(),
                    UserId = "1",
                    Country = "Nigeria",
                    PhoneNumber = "+23456734567802",
                    TimeUpdated = DateTimeOffset.UtcNow,
                    TimeCreated = DateTimeOffset.UtcNow
                });


            //modelBuilder.Entity<OrderItem>()
             //   .HasKey(k => new { k.ProductId, k.OrderId });
            modelBuilder.Entity<OrderItem>()
                .HasData(
                new OrderItem
                {
                    Id = 1,
                    Quantity = 2,
                    Price = 900.000,
                    ProductId = 3,
                    OrderId = 1,
                    TimeUpdated = DateTimeOffset.UtcNow,
                    TimeCreated = DateTimeOffset.UtcNow
                });

            modelBuilder.Entity<ShoppingCartItem>()
                .HasData(
                new ShoppingCartItem
                {
                    Id = 1,
                    ShoppingCartId = "21",
                    ProductId = 1,
                    Quantity = 2,
                    TimeUpdated = DateTimeOffset.UtcNow,
                    TimeCreated = DateTimeOffset.UtcNow
                });
        }
    }
}
