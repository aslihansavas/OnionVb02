using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;

public class CreateCategoryCommand :IRequest<CreateCategoryCommandResult>
{
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
