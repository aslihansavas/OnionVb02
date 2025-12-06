using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CustomMappers.CommandMappers;

public class CreateOrderCommandMapper : ICustomMapper<CreateOrderCommand, Order>
{
    public Order Map(CreateOrderCommand source)
    {
        return new Order
        {
            ShippingAddress = source.ShippingAddress,
            AppUserId = source.AppUserId,
            CreatedDate = DateTime.Now,
            Status = DataStatus.Inserted
        };
    }

    public List<Order> MapList(List<CreateOrderCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class UpdateOrderCommandMapper : ICustomMapper<UpdateOrderCommand, Order>
{
    public Order Map(UpdateOrderCommand source)
    {
        return new Order
        {
            Id = source.Id,
            ShippingAddress = source.ShippingAddress,
            UpdatedDate = DateTime.Now,
            Status = DataStatus.Updated
        };
    }

    public List<Order> MapList(List<UpdateOrderCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

public class RemoveOrderCommandMapper : ICustomMapper<RemoveOrderCommand, Order>
{
    public Order Map(RemoveOrderCommand source)
    {
        return new Order
        {
            Id = source.Id,
            Status = DataStatus.Deleted
        };
    }

    public List<Order> MapList(List<RemoveOrderCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

