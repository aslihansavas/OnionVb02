using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.CategoryModify;

public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, RemoveCategoryCommandResult>
{
    private readonly ICategoryRepository _repository;

    public RemoveCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<RemoveCategoryCommandResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        Category value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return new RemoveCategoryCommandResult
        {
            IsSuccess=true,
            Message = $"{value.Id} Id 'li Category silindi."

        };
    }
}
