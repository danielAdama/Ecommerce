using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using Ecommerce.Mvc.Core.Domains.Accounts.CQRS.Commands.Register;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse>
    {
        //public string? ProductImage { get; set; }
#nullable disable
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CreateProductCommand : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommand() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
            RuleFor(x => x.IsAvailable).NotNull().NotEmpty();
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse>
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<AboutYourSelfCommandHandler> _logger;
        private readonly UserManager<EcommerceUser> _userManager;
        public AboutYourSelfCommandHandler(
            EcommerceDbContext context,
            ILogger<AboutYourSelfCommandHandler> logger,
            UserManager<EcommerceUser> userManager
        )
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
    }
}
