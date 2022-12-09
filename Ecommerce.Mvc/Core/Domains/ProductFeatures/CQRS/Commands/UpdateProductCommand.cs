using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Utilities.Enums;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Commands
{
    public class UpdateProductCommand : IRequest<BaseResponse>
    {
        //public string? ProductImage { get; set; }
        public long Id { get; set; }
#nullable disable
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class UpdateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
            RuleFor(x => x.IsAvailable).NotNull().NotEmpty();
        }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseResponse>
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        private readonly UserManager<EcommerceUser> _userManager;
        public UpdateProductCommandHandler(
            EcommerceDbContext context,
            ILogger<UpdateProductCommandHandler> logger,
            UserManager<EcommerceUser> userManager
        )
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<BaseResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                if (product is null)
                {
                    _logger.LogInformation($"UpdateProductCommand => Product not available to edit. Please create product.");
                    return new BaseResponse(false, "Product not available to edit. Please create product.");
                }
                product.Name = request.ProductName;
                product.Price = request.Price;
                product.IsAvailable = request.IsAvailable;
                await _context.SaveChangesAsync(cancellationToken);
                return new BaseResponse(true, "Operation successful");
            }
            catch ( Exception ex )
            {
                _logger.LogError(ex, "APPLICATION ERROR while try to edit product");
                return new BaseResponse(false, "Applicaton ran into an error while trying to edit product, please try again. Contact support if you are not able to continue after multiple tries");
            }
        }
    }


}
