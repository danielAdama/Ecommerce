using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Data.Static;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using Ecommerce.Mvc.Core.Domains.Accounts.CQRS.Commands.Register;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Principal;
//using static Ecommerce.Infrastructure.Data.Entities.Category;

namespace Ecommerce.Mvc.Core.Domains.Accounts.CQRS.Commands.Register
{
    public class AboutYourSelfCommand : IRequest<BaseResponse>
    {
#nullable disable
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //public string Country { get; set; }
    }

    public class AboutYourSelfCommandValidator : AbstractValidator<AboutYourSelfCommand>
    {
        public AboutYourSelfCommandValidator() 
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.EmailAddress).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty();
            //RuleFor(x => x.Country).NotNull().NotEmpty();
        }

    }

    public class AboutYourSelfCommandHandler : IRequestHandler<AboutYourSelfCommand, BaseResponse>
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
        public async Task<BaseResponse> Handle(AboutYourSelfCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string email = request.EmailAddress.Trim().ToLower();
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    _logger.LogInformation($"AboutYourSelfCommand => {email} is already in use");
                    return new BaseResponse(false, "Email address is already in use");
                }

                if (request.Password.Length != request.ConfirmPassword.Length || request.Password != request.ConfirmPassword)
                {
                    _logger.LogInformation($"AboutYourSelfCommand => incorrect password");
                    return new BaseResponse(false, $"Incorrect Password");
                }
                using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
                try
                {
                    //var countryoforder = new order
                    //{
                    //    country = request.country
                    //};

                    var newUser = new EcommerceUser
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = email,
                        UserName = email,
                        //CountryId = countryOfOrder.Id
                        TimeCreated = DateTime.UtcNow,
                        TimeUpdated = DateTime.UtcNow
                    };

                    var newUserResponse = await _userManager.CreateAsync(newUser, request.Password);

                    if (!newUserResponse.Succeeded)
                    {
                        _logger.LogInformation($"AboutYourSelfCommand => Password too short, requires non-alphabet");
                        return new BaseResponse(false, $"Password too short, requires non-alphabet. It do not meet the requirements");
                    }
                    //await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                    await transaction.CommitAsync(cancellationToken);
                    return new BaseResponse(true, "Operation successful");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "APPLICATION ERROR INSIDE TRANSACTION while creating user");
                    await transaction.RollbackAsync(cancellationToken);
                    return new BaseResponse(false, "Applicaton ran into an error while trying to create user, please try again. Contact support if you are not able to continue after multiple tries");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "APPLICATION ERROR while creating user");
                return new BaseResponse(false, "Applicaton ran into an error while trying to create user, please try again. Contact support if you are not able to continue after multiple tries");
            }
            
        }
    }


}
