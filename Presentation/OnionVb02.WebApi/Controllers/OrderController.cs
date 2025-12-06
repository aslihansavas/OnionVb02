using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
         private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            List<GetOrdersQueryResult> appUsers = await _mediator.Send(new GetOrdersQuery());
            return Ok(appUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            GetOrderByIdQueryResult value = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            CreateOrderCommandResult result =await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            UpdateOrderCommandResult result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
           RemoveOrderCommandResult result = await _mediator.Send(new RemoveOrderCommand(id));
            return Ok(result);
        }
    }
}
