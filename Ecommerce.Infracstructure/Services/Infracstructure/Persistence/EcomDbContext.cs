using Ecommerce.Infracstructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommerce.Infracstructure.Services.Infracstructure.Persistence
{
    public class EcomDbContext : IdentityDbContext<EcommerceUser>
    {
#nullable disable
        public EcomDbContext(DbContextOptions<EcomDbContext> options) 
            : base(options)
        { }

        public DbSet<EcommerceUser> EcommerceUsers { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        // public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Add the Postgres Extension for UUID generation
			modelBuilder.HasPostgresExtension("uuid-ossp");
			modelBuilder.Seed();
		}
    }
}
