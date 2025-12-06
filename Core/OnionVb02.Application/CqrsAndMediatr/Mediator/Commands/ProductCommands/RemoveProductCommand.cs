using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;

public class RemoveProductCommand : IRequest<RemoveProductCommandResult>
{
    public int Id { get; set; }

    public RemoveProductCommand(int id)
    {
        Id = id;
    }
}
