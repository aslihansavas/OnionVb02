using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CustomMappers.CommandMappers;

public class CreateOrderDetailCommandMapper : ICustomMapper<CreateOrderDetailCommand, OrderDetail>
{
    public OrderDetail Map(CreateOrderDetailCommand source)
    {
        return new OrderDetail
        {
            OrderId = source.OrderId,
            ProductId = source.ProductId,
            CreatedDate = DateTime.Now,
            Status = DataStatus.Inserted
        };
    }

    public List<OrderDetail> MapList(List<CreateOrderDetailCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class UpdateOrderDetailCommandMapper : ICustomMapper<UpdateOrderDetailCommand, OrderDetail>
{
    public OrderDetail Map(UpdateOrderDetailCommand source)
    {
        return new OrderDetail
        {
            Id = source.Id,
            OrderId = source.OrderId,
            ProductId = source.ProductId,
            UpdatedDate = DateTime.Now,
            Status = DataStatus.Updated
        };
    }

    public List<OrderDetail> MapList(List<UpdateOrderDetailCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class RemoveOrderDetailCommandMapper : ICustomMapper<RemoveOrderDetailCommand, OrderDetail>
{
    public OrderDetail Map(RemoveOrderDetailCommand source)
    {
        return new OrderDetail
        {
            Id = source.Id,
            Status = DataStatus.Deleted
        };
    }

    public List<OrderDetail> MapList(List<RemoveOrderDetailCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

