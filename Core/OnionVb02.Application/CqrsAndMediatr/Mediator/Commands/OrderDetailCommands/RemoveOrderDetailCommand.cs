using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;

public class RemoveOrderDetailCommand :IRequest<RemoveOrderDetailCommandResult>
{
    public int Id { get; set; }

    public RemoveOrderDetailCommand(int id)
    {
        Id = id;
    }
}
