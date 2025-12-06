using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.ProductModify;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, RemoveProductCommandResult>
{
    private readonly IProductRepository _repository;

    public RemoveProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<RemoveProductCommandResult> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        Product value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return new RemoveProductCommandResult
        {
            IsSuccess=true,
            Message = "Silindi"
        };
    }
}
