using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailModify;

public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreateOrderDetailCommandResult>
{
    private readonly IOrderDetailRepository _repository;

    public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateOrderDetailCommandResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail orderDetail = new OrderDetail()
        {
            OrderId = request.OrderId,
            ProductId=request.ProductId
        };
        await _repository.CreateAsync(orderDetail);
        return new CreateOrderDetailCommandResult
        {
            IsSuccess=true,
            Message = "sipariş detayi oluşturuldu."
        };
    }
}
