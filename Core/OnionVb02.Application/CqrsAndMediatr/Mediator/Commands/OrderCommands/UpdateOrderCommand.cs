using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;

public class UpdateOrderCommand : IRequest<UpdateOrderCommandResult>
{
    public int Id { get; set; }
    public string ShippingAddress { get; set; }
}
