using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.ResultMappers;

public class OrderToResultMapper : ICustomMapper<Order, GetOrdersQueryResult>
{
    public GetOrdersQueryResult Map(Order source)
    {
        return new GetOrdersQueryResult
        {
            Id = source.Id,
            ShippingAdresss = source.ShippingAddress
        };
    }

    public List<GetOrdersQueryResult> MapList(List<Order> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class OrderToByIdResultMapper : ICustomMapper<Order, GetOrderByIdQueryResult>
{
    public GetOrderByIdQueryResult Map(Order source)
    {
        return new GetOrderByIdQueryResult
        {
            Id = source.Id,
            ShippingAdresss = source.ShippingAddress
        };
    }

    public List<GetOrderByIdQueryResult> MapList(List<Order> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

