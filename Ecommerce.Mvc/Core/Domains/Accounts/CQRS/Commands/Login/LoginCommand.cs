using Ecommerce.Infrastructure.Data.Entities;
using Ecommerce.Infrastructure.Data.Model;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Mvc.Core.Domains.Accounts.CQRS.Commands.Login
{
    public class LoginCommand : IRequest<BaseResponse>
    {
#nullable disable
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.EmailAddress).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponse>
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly UserManager<EcommerceUser> _userManager;
        private readonly SignInManager<EcommerceUser> _signInManager;


        public LoginCommandHandler(
            EcommerceDbContext context,
            ILogger<LoginCommandHandler> logger,
            UserManager<EcommerceUser> userManager,
            SignInManager<EcommerceUser> signInManager
        )
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<BaseResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.EmailAddress);
                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, request.Password);
                    if (!passwordCheck)
                    {
                        _logger.LogInformation("LOGIN > User entered a wrong password");
                        return new BaseResponse(false, "Wrong password. Please try again");
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
                    if (!result.Succeeded)
                    {
                        _logger.LogInformation("LOGIN > User is not sign in");
                        return new BaseResponse(false, "Wrong credentials. Please try again");
                    }
                    return new BaseResponse(true, "Operation successful");
                }
                return new BaseResponse(false, "User not found. Please sign up");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LOGIN > APPLICATION ERROR while creating user");
                return new BaseResponse(false, "Wrong credentials. Please try again");
            }
        }
    }
}
