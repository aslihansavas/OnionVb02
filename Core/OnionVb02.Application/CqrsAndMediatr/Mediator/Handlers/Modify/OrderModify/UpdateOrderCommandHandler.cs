using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderModify;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResult>
{
    private readonly IOrderRepository _repository;

    public UpdateOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        Order value = await _repository.GetByIdAsync(request.Id);
        value.ShippingAddress = request.ShippingAddress;
        await _repository.SaveChangesAsync();
        return new UpdateOrderCommandResult
        {
            IsSuccess=true,
            Message =" Güncellendi"
        };
    }
}
