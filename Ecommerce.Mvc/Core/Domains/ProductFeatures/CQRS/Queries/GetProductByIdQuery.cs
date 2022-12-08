using MediatR;
using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries
{
    public class GetProductByIdQuery : IRequest<BaseResponse>
    {
        public long productId { get; set; }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, BaseResponse>
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;
        public GetProductByIdQueryHandler(
            EcommerceDbContext context,
            ILogger<GetProductByIdQueryHandler> logger
        )
        {
            _context = context;
            _logger = logger;
        }
        public async Task<BaseResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                bool isProduct = await _context.Products.AnyAsync(x => x.Id.Equals(query.productId), cancellationToken);
                if (!isProduct)
                {
                    _logger.LogInformation($"GetProductByIdQuery => Product not available");
                    return new BaseResponse(false, $"The Product is not available. Please come back in 45 minutes time for this product");
                }
                return new BaseResponse(true, "Operation successful");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "APPLICATION ERROR while searching for product");
                return new BaseResponse(false, "Applicaton ran into an error while trying to get product, please try again. Contact support if you are not able to continue after multiple tries");
            }
        }
    }
}
