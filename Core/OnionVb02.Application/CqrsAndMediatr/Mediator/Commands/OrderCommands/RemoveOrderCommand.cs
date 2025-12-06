using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;

public class RemoveOrderCommand :IRequest<RemoveOrderCommandResult>
{
    public int Id { get; set; }

    public RemoveOrderCommand(int id)
    {
        Id = id;
    }
}
