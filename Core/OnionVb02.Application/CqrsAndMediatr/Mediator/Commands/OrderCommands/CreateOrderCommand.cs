using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;

public class CreateOrderCommand :IRequest<CreateOrderCommandResult>
{
    public string ShippingAddress { get; set; }
    public int AppUserId { get; set; }

}
