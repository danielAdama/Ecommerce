using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries
{
    public class SearchForProductByNameQuery : IRequest<Product>
    {
#nullable disable
        public string search { get; set; }
        public class SearchForProductByNameQueryHandler : IRequestHandler<SearchForProductByNameQuery, Product>
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
            public async Task<Product> Handle(SearchForProductByNameQuery query, CancellationToken cancellationToken)
            {
                string search = query.search.ToLower();
                if (string.IsNullOrEmpty(search) ||
                !await _context.Products.AnyAsync(x => x.Name.ToLower().Equals(search), cancellationToken))
                {
                    _logger.LogInformation($"SearchForProductByNameQuery => Product is not available");
                    // return new BaseResponse(false, $"The Product is not available. Please come back in 45 minutes time for this product");
                }
                //var productSearch = await _context.Products.Where(x => string.Equals(x.Name.ToLower(), search, StringComparison.CurrentCultureIgnoreCase)).ToListAsync(cancellationToken);
                var productSearch = await _context.Products.Where(x => x.Name.ToLower().Equals(search)).FirstOrDefaultAsync();
                if (productSearch == null)
                {
                    _logger.LogInformation($"SearchForProductByNameQuery => Product is not available");
                    return null;
                        //return new BaseResponse(false, $"The Product is not available. Please come back in 45 minutes time for this product");
                    }
                return productSearch;
            }

        }
    }
}
