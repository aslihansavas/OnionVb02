using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;

public class CreateOrderDetailCommand : IRequest<CreateOrderDetailCommandResult>
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}
