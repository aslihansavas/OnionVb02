using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
         private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            List<GetOrderDetailsQueryResult> appUsers = await _mediator.Send(new GetOrderDetailsQuery());
            return Ok(appUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            GetOrderDetailByIdQueryResult value = await _mediator.Send(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
           CreateOrderDetailCommandResult result = await _mediator.Send(command);  
            return Ok(result);  
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            UpdateOrderDetailCommandResult result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
             RemoveOrderDetailCommandResult result = await _mediator.Send(new RemoveOrderDetailCommand(id));
            return Ok(result);
        }
    }
}
