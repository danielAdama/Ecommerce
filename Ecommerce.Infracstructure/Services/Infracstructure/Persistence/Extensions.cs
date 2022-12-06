using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ecommerce.Infracstructure.Services.Infracstructure.Persistence
{
    public static class Extensions
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EcomDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("Ecommerce"));
                //option.EnableSensitiveDataLogging();
            });

            return services;
        }

        public static void Seed(this ModelBuilder modelBuilder) { }
    }
}
