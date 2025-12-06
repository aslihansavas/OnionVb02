using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ProductsList()
        {
            List<GetProductsQueryResult> products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetProductByIdQueryResult product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            CreateProductCommandResult result = await _mediator.Send(command);  
            return Ok(result);  
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            UpdateProductCommandResult result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(RemoveProductCommand command)
        {
            RemoveProductCommandResult result =await _mediator.Send(command);
            return Ok(result);
        }
    }
}
