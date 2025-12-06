using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderRead;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<GetOrdersQueryResult>>
{
    private readonly IOrderRepository _repository;
    private readonly ICustomMapper<Order, GetOrdersQueryResult> _mapper;

    public GetOrdersQueryHandler(
        IOrderRepository repository,
        ICustomMapper<Order, GetOrdersQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetOrdersQueryResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        List<Order> orders = await _repository.GetAllAsync();
        return _mapper.MapList(orders);
    }
}
