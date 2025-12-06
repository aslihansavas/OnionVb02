using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailModify;

public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand, RemoveOrderDetailCommandResult>
{
    private readonly IOrderDetailRepository _repository;

    public RemoveOrderDetailCommandHandler(IOrderDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<RemoveOrderDetailCommandResult> Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
        return new RemoveOrderDetailCommandResult
        {
            IsSuccess=true,
            Message ="Silindi"
        };
    }
}
