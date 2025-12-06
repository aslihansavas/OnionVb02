using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderModify;

public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, RemoveOrderCommandResult>
{
    private readonly IOrderRepository _repository;

    public RemoveOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<RemoveOrderCommandResult> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        Order value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return new RemoveOrderCommandResult
        {
            IsSuccess=true,
            Message ="Silindi"
        };
    }
}
