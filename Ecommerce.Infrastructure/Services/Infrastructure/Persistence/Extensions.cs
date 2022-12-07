using Ecommerce.Infrastructure.Data.Entities;
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
            // modelBuilder.Entity<Category>()
            //    .HasData(
            //     new Seller { Id = 1, 
            //         FullName = "Akachi Brown",
            //         GenderType = Utilities.Enums.GenderTypeEnum.Male,
            //         PictureUrl = "",
            //         TimeCreated = DateTimeOffset.UtcNow,
            //         TimeUpdated = DateTimeOffset.UtcNow
            //     });

            //modelBuilder.Entity<Product>()
            //     .HasData(
            //     new Product
            //     {
            //         Id = 1,
            //         Name = "Asus",
            //         Price = 250.000,
            //         //ProductCategory = Utilities.Enums.ProductCategoryEnum.Laptop,
            //         ProductImage = "",
            //         IsAvailable = true,
            //         TimeUpdated = DateTimeOffset.UtcNow,
            //         TimeCreated = DateTimeOffset.UtcNow
            //     });

            //modelBuilder.Entity<Order>()
            //    .HasData(
            //    new Order
            //    {
            //        Id = 1,
            //        TrackingId = Guid.NewGuid(),
            //        UserId = 2,
            //        Country = "Nigeria",
            //        PhoneNumber = "+23456734567802",
            //        TimeUpdated = DateTimeOffset.UtcNow,
            //        TimeCreated = DateTimeOffset.UtcNow
            //    });


            //modelBuilder.Entity<OrderItem>()
            //    .HasKey(k => new { k.ProductId, k.OrderId });
            //modelBuilder.Entity<OrderItem>()
            //    .HasData(
            //    new OrderItem
            //    {
            //        Id = 1,
            //        SelectedAmount = 2,
            //        Price = 500.000,
            //        TimeUpdated = DateTimeOffset.UtcNow,
            //        TimeCreated = DateTimeOffset.UtcNow
            //    });
        }
    }
}
