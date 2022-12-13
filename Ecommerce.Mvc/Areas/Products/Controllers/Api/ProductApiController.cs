using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Ecommerce.Mvc.Core.Domains.Accounts.CQRS.Commands.Login;
using Ecommerce.Mvc.Core.Domains.ProductFeatures.CQRS.Commands;

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
            //if (!response.Status) return BadRequest(response);
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
            //if (!response.Status) return BadRequest(response);
            return Ok(response);
        }

        [Route("SearchForProductByNameQuery/{search}")]
        public async Task<IActionResult> SearchForProductByNameQuery([FromRoute] string search)
        {
            var query = new SearchForProductByNameQuery
            {
                search = search
            };
            var response = await _sender.Send(query);
            if (!response.Status) return BadRequest(response);
            return Ok(response);
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            //return Ok(new { Status = true, Message = "Working", Data = command });
            var response = await _sender.Send(command);
            if (!response.Status) return BadRequest(response);
            return Ok(response);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] UpdateProductCommand command)
        {
            var query = new UpdateProductCommand
            {
                Id = id,
            };
            command.Id = query.Id;
            var response = await _sender.Send(command);
            if (!response.Status) return BadRequest(response);
            return Ok(response);
        }

        [Route("DeleteProductById")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductById([FromBody] DeleteProductByIdCommand command)
        {
            return Ok(new { Status = true, Message = "Working", Data = command });
            //var response = await _sender.Send(command);
            //if (!response.Status) return BadRequest(response);
            //return Ok(response);
        }
    }
}
