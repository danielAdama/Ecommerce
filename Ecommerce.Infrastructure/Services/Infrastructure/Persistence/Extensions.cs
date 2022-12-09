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
            modelBuilder.Entity<Category>()
               .HasData(
                new Category
                {
                    Id = 1,
                    ProductCategory = (ProductCategoryEnum)1,
                    TimeCreated = DateTimeOffset.UtcNow,
                    TimeUpdated = DateTimeOffset.UtcNow
                },
                new Category
                {
                    Id = 2,
                    ProductCategory = (ProductCategoryEnum)2,
                    TimeCreated = DateTimeOffset.UtcNow,
                    TimeUpdated = DateTimeOffset.UtcNow
                });


            modelBuilder.Entity<Product>()
                 .HasData(
                 new Product
                 {
                     Id = 1,
                     Name = "Asus",
                     Price = 250.000,
                     CategoryId = 1,
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
                     CategoryId = 1,
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
                     CategoryId = 1,
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
                     CategoryId = 2,
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
                    //ProductId = 3,
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
