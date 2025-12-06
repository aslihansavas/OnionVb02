using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderModify;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
{
    private readonly IOrderRepository _repository;
    private readonly ICustomMapper<CreateOrderCommand, Order> _mapper;

    public CreateOrderCommandHandler(
        IOrderRepository repository,
        ICustomMapper<CreateOrderCommand, Order> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = _mapper.Map(request);
        await _repository.CreateAsync(order);
        
        return new CreateOrderCommandResult
        {
            IsSuccess = true,
            Message = "Sipariş Oluşturuldu"
        };
    }
}
