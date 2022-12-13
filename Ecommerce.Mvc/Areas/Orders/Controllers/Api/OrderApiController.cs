using Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Mvc.Areas.Orders.Controllers.Api
{
    [Route("api/Orders")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly ISender _sender;

        public OrderApiController(ISender sender) => _sender = sender;

        [Route("AddProductToCart/{productId}")]
        public async Task<IActionResult> AddProductToCart([FromRoute] long productId)
        {
            throw new NotImplementedException();
            //return Ok(new { Status = true, Message = "Working" });
            //var query = new AddProductToCartQuery
            //{
            //    productId = productId
            //};
            //var response = await _sender.Send(query);
            //if (!response.Status) return BadRequest(response);
            //return Ok(response);
        }
    }
}
