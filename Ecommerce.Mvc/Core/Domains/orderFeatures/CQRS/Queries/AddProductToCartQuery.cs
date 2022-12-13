//using Ecommerce.Infrastructure.Data.Entities;
//using Ecommerce.Infrastructure.Data.Cart;
//using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
//using Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace Ecommerce.Mvc.Core.Domains.orderFeatures.CQRS.Queries
//{
//    public class AddProductToCartQuery : IRequest<Product>
//    {
//        public long productId { get; set; }
//        public class AddProductToCartQueryHandler : IRequestHandler<AddProductToCartQuery, Product>
//        {
//            private readonly EcommerceDbContext _context;
//            private readonly ILogger<AddProductToCartQueryHandler> _logger;

//            public AddProductToCartQueryHandler(
//                EcommerceDbContext context,
//                ILogger<AddProductToCartQueryHandler> logger
//            )
//            {
//                _context = context;
//                _logger = logger;
//            }

//            public async Task<Product> Handle(AddProductToCartQuery query, CancellationToken cancellationToken)
//            {
//                if (await _context.Products.AnyAsync(x => x.Id.Equals(query.productId), cancellationToken) &&
//                    await _context.Products.AnyAsync(x => x.IsAvailable.Equals(true), cancellationToken))
//                {
//                    var product = await _context.Products.Where(x => x.Id.Equals(query.productId)).FirstOrDefaultAsync();
//                    var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Product.Id == query.productId && x.ShoppingCartId == ShoppingCartId);
//                    // Add product to cart
//                    var item = new ShoppingCartItem
//                    {
//                        ProductId = query.productId,
//                        Quantity = 1
//                    };
//                    await _context.ShoppingCartItems.AddAsync(item, cancellationToken);
//                    else
//                    {
//                        shoppingCartItem.Quantity++;
//                    }
//                    await _context.SaveChangesAsync(cancellationToken);
//                }


//            }
//        }
//    }
//}
