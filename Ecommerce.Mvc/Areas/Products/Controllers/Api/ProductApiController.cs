using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ecommerce.Mvc.Areas.Products.Controllers.Api
{
    [Route("api/Products")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductApiController(ISender sender) => _sender = sender;

        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            //return Ok(new { Status = true, Message = "Working"});
            var query = new GetAllProductsQuery();
            var response = await _sender.Send(query);
            if (!response.Status) return BadRequest(response);
            return Ok(response);
        }

        [Route("GetProductById/{productId}")]
        public async Task<IActionResult> GetProductById([FromRoute] long productId)
        {
            //return Ok(new { Status = true, Message = "Working" });
            var query = new GetProductByIdQuery
            {
                productId = productId
            };
            var response = await _sender.Send(query);
            if (!response.Status) return BadRequest(response);
            return Ok(response);
        }


    }
}
