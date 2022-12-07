using Ecommerce.Mvc.Core.Domains.Accounts.CQRS.Commands.Login;
using Ecommerce.Mvc.Core.Domains.Accounts.CQRS.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Areas.Accounts.Controllers.Api
{
    [Route("api/Accounts/Identity")]
    [ApiController]
    public class IdentityApiController : ControllerBase
    {
        private readonly ISender _sender;

        public IdentityApiController(ISender sender) => _sender = sender;

        [Route("Register/AboutYourSelf")]
        [HttpPost]
        public async Task<IActionResult> AboutYourSelf([FromBody] AboutYourSelfCommand command)
        {
            //return Ok(new { Status = true, Message = "Working", Data = command });
            var response = await _sender.Send(command);
            if (!response.Status) return BadRequest(response);
            return Ok(response);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            //return Ok(new { Status = true, Message = "Working", Data = command });
            var response = await _sender.Send(command);
            if (!response.Status) return BadRequest(response);
            return Ok(response);
        }
    }
}
