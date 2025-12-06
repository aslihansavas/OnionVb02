using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.ResultMappers;

public class OrderDetailToResultMapper : ICustomMapper<OrderDetail, GetOrderDetailsQueryResult>
{
    public GetOrderDetailsQueryResult Map(OrderDetail source)
    {
        return new GetOrderDetailsQueryResult
        {
            Id = source.Id,
            OrderId = source.OrderId,
            ProductId = source.ProductId
        };
    }

    public List<GetOrderDetailsQueryResult> MapList(List<OrderDetail> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class OrderDetailToByIdResultMapper : ICustomMapper<OrderDetail, GetOrderDetailByIdQueryResult>
{
    public GetOrderDetailByIdQueryResult Map(OrderDetail source)
    {
        return new GetOrderDetailByIdQueryResult
        {
            Id = source.Id,
            OrderId = source.OrderId,
            ProductId = source.ProductId
        };
    }

    public List<GetOrderDetailByIdQueryResult> MapList(List<OrderDetail> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

