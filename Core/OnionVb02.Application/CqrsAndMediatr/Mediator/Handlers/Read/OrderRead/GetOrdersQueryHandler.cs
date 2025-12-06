using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderRead;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<GetOrdersQueryResult>>
{
    private readonly IOrderRepository _repository;

    public GetOrdersQueryHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrdersQueryResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        List<Order> orders = await _repository.GetAllAsync();
        return orders.Select(x=> new GetOrdersQueryResult
        {
            Id=x.Id,
            ShippingAdresss=x.ShippingAddress
        }).ToList();
    }
}
