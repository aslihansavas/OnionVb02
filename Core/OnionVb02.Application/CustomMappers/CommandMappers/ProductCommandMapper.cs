using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CustomMappers.CommandMappers;

// CreateCommand → Entity Mapper
public class CreateProductCommandMapper : ICustomMapper<CreateProductCommand, Product>
{
    public Product Map(CreateProductCommand source)
    {
        return new Product
        {
            ProductName = source.ProductName,
            UnitPrice = source.UnitPrice,
            CategoryId = source.CategoryId,
            CreatedDate = DateTime.Now,
            Status = DataStatus.Inserted
        };
    }

    public List<Product> MapList(List<CreateProductCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

// UpdateCommand → Entity Mapper
public class UpdateProductCommandMapper : ICustomMapper<UpdateProductCommand, Product>
{
    public Product Map(UpdateProductCommand source)
    {
        return new Product
        {
            Id = source.Id,
            ProductName = source.ProductName,
            UnitPrice = source.UnitPrice,
            CategoryId = source.CategoryId,
            UpdatedDate = DateTime.Now,
            Status = DataStatus.Updated
        };
    }

    public List<Product> MapList(List<UpdateProductCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

// RemoveCommand → Entity Mapper (silme için Id'den entity)
public class RemoveProductCommandMapper : ICustomMapper<RemoveProductCommand, Product>
{
    public Product Map(RemoveProductCommand source)
    {
        return new Product
        {
            Id = source.Id,
            Status = DataStatus.Deleted
        };
    }

    public List<Product> MapList(List<RemoveProductCommand> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}
