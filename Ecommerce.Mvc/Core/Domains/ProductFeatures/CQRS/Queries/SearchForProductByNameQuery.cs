using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries
{
    public class SearchForProductByNameQuery : IRequest<BaseResponse>
    {
#nullable disable
        public string search { get; set; }
        public class SearchForProductByNameQueryHandler : IRequestHandler<SearchForProductByNameQuery, BaseResponse>
        {
            private readonly EcommerceDbContext _context;
            private readonly ILogger<SearchForProductByNameQueryHandler> _logger;

            public SearchForProductByNameQueryHandler(
            EcommerceDbContext context,
            ILogger<SearchForProductByNameQueryHandler> logger
            )
            {
                _context = context;
                _logger = logger;
            }
            public async Task<BaseResponse> Handle(SearchForProductByNameQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    string search = query.search.ToLower();
                    if (string.IsNullOrEmpty(search) ||
                    !await _context.Products.AnyAsync(x => x.Name.ToLower().Equals(search), cancellationToken))
                    {
                        _logger.LogInformation($"SearchForProductByNameQuery => Product is not available");
                        return new BaseResponse(false, $"The Product is not available. Please come back in 45 minutes time for this product");
                    }
                    //var productSearch = await _context.Products.Where(x => string.Equals(x.Name.ToLower(), search, StringComparison.CurrentCultureIgnoreCase)).ToListAsync(cancellationToken);
                    var productSearch = await _context.Products.AnyAsync(x => x.Name.ToLower().Equals(search), cancellationToken);
                    if (!productSearch)
                    {
                        _logger.LogInformation($"SearchForProductByNameQuery => Product is not available");
                        return new BaseResponse(false, $"The Product is not available. Please come back in 45 minutes time for this product");
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
