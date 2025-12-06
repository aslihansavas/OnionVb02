using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;

public class RemoveCategoryCommand :IRequest<RemoveCategoryCommandResult>
{
    public int Id { get; set; }

    public RemoveCategoryCommand(int id)
    {
        Id = id;
    }
}
