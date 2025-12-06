using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderDetailRead;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
{
    private readonly IOrderDetailRepository _repository;

    public GetOrderByIdQueryHandler(IOrderDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        OrderDetail orderDetail = await _repository.GetByIdAsync(request.Id);
        return new GetOrderDetailByIdQueryResult
        {
            Id=orderDetail.Id,
            ProductId=orderDetail.ProductId,
            ProductName=orderDetail.Product.ProductName,
            UnitPrice=orderDetail.Product.UnitPrice,
            OrderId=orderDetail.OrderId,
            ShippingAddress=orderDetail.Order.ShippingAddress
        };
    }
}
