using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries
{
    public class GetAllProductsQuery : IRequest<BaseResponse>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, BaseResponse>
        {
            private readonly EcommerceDbContext _context;
            private readonly ILogger<GetAllProductsQueryHandler> _logger;
            private readonly UserManager<EcommerceUser> _userManager;

            public GetAllProductsQueryHandler(
                EcommerceDbContext context,
                ILogger<GetAllProductsQueryHandler> logger,
                UserManager<EcommerceUser> userManager
            )
            {
                _context = context;
                _logger = logger;
                _userManager = userManager;
            }

            public async Task<BaseResponse> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var products = await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
                    if (products is null)
                    {
                        _logger.LogInformation($"GetAllProductsQuery => No available Products at the moment");
                        return new BaseResponse(false, $"No available Products at the moment. Please check back tomorrow for this product");
                    }
                    return new BaseResponse(true, "Operation successful");
                }
                catch ( Exception ex )
                {
                    _logger.LogError(ex, "APPLICATION ERROR while searching for product");
                    return new BaseResponse(false, "Applicaton ran into an error while trying to get product, please try again. Contact support if you are not able to continue after multiple tries");
                }
            }
        }
    }
}
