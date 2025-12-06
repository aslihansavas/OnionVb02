using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailModify;

public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, UpdateOrderDetailCommandResult>
{
    private readonly IOrderDetailRepository _repository;

    public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateOrderDetailCommandResult> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail value = await _repository.GetByIdAsync(request.Id);
        value.OrderId = request.OrderId;
        value.ProductId=request.ProductId;
        await _repository.SaveChangesAsync();
        return new UpdateOrderDetailCommandResult{
            IsSuccess=true,
            Message ="Güncellendi"
        };
    }
}
