using MediatR;
using System.Reflection;

namespace Ecommerce.Mvc.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
            services.AddHttpClient();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
