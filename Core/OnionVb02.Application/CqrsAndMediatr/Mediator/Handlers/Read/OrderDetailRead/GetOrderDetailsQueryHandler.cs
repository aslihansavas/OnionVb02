using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderDetailRead;

public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, List<GetOrderDetailsQueryResult>>
{
    private readonly IOrderDetailRepository _repository;

    public GetOrderDetailsQueryHandler(IOrderDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderDetailsQueryResult>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        List<OrderDetail> value = await _repository.GetAllAsync();
        return value.Select(x=>new GetOrderDetailsQueryResult
        {
            Id=x.Id,
            ProductId=x.ProductId,
            ProductName=x.Product.ProductName,
            OrderId=x.OrderId,
            ShippingAddress=x.Order.ShippingAddress,
            

        }).ToList();
    }
}
