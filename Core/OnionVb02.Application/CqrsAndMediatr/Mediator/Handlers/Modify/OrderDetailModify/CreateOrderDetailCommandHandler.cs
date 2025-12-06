using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetailModify;

public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreateOrderDetailCommandResult>
{
    private readonly IOrderDetailRepository _repository;
    private readonly ICustomMapper<CreateOrderDetailCommand, OrderDetail> _mapper;

    public CreateOrderDetailCommandHandler(
        IOrderDetailRepository repository,
        ICustomMapper<CreateOrderDetailCommand, OrderDetail> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateOrderDetailCommandResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail orderDetail = _mapper.Map(request);
        await _repository.CreateAsync(orderDetail);
        
        return new CreateOrderDetailCommandResult
        {
            IsSuccess = true,
            Message = "Sipariş detayı oluşturuldu."
        };
    }
}
