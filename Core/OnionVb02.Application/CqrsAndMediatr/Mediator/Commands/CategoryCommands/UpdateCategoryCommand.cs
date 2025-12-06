using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;

public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResult>
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
