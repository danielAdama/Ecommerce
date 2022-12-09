using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Utilities.Enums;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse>
    {
        //public string? ProductImage { get; set; }
#nullable disable
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
            RuleFor(x => x.IsAvailable).NotNull().NotEmpty();
            RuleFor(x => x.ProductCategory).NotNull().NotEmpty();
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse>
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly UserManager<EcommerceUser> _userManager;
        public CreateProductCommandHandler(
            EcommerceDbContext context,
            ILogger<CreateProductCommandHandler> logger,
            UserManager<EcommerceUser> userManager
        )
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<BaseResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Delete the database seed and migrate it again and convert enum(product category to long)
                using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
                try
                {
                    if (await _context.Products.AnyAsync(x => x.Name.Equals(request.ProductName)) && 
                        await _context.Products.AnyAsync(x => x.Price.Equals(request.Price)) && 
                        await _context.Categories.AnyAsync(x => x.ProductCategory.Equals(request.ProductCategory)))
                    {
                        _logger.LogInformation($"CreateProductCommand => The product {request.ProductName} of price {request.Price} and {request.ProductCategory} exists");
                        return new BaseResponse(false, "Email address is already in use");
                    }
                    if (request.ProductName != null && request.Price != 0)
                    {
                        var category = new Category
                        {
                            ProductCategory = (ProductCategoryEnum)(int)request.ProductCategory
                        };
                        Console.WriteLine(category);
                        await _context.Categories.AddAsync(category, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);
                        var productDetails = new Product
                        {
                            Name = request.ProductName,
                            Price = request.Price,
                            CategoryId = ((long)category.ProductCategory),
                            IsAvailable = request.IsAvailable,
                            TimeCreated = DateTime.UtcNow,
                            TimeUpdated = DateTime.UtcNow,
                        };
                        await _context.Products.AddAsync(productDetails, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    await transaction.CommitAsync(cancellationToken);
                    return new BaseResponse(true, "Operation successful");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "APPLICATION ERROR INSIDE TRANSACTION while creating product");
                    await transaction.RollbackAsync(cancellationToken);
                    return new BaseResponse(false, "Applicaton ran into an error while trying to create product, please try again. Contact support if you are not able to continue after multiple tries");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "APPLICATION ERROR while creating product");
                return new BaseResponse(false, "Applicaton ran into an error while trying to create product, please try again. Contact support if you are not able to continue after multiple tries");
            }

        }
    }
}
