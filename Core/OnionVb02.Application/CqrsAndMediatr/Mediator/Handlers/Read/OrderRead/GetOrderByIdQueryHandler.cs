using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderRead;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
{
    private readonly IOrderRepository _repository;
    private readonly ICustomMapper<Order, GetOrderByIdQueryResult> _mapper;

    public GetOrderByIdQueryHandler(
        IOrderRepository repository,
        ICustomMapper<Order, GetOrderByIdQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order order = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map(order);
    }
}
