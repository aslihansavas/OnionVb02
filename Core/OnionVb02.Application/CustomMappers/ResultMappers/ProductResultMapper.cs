using System;
using System.Collections.Generic;
using System.Linq;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.ResultMappers;

// Entity → QueryResult Mapper
public class ProductToResultMapper : ICustomMapper<Product, GetProductsQueryResult>
{
    public GetProductsQueryResult Map(Product source)
    {
        return new GetProductsQueryResult
        {
            Id = source.Id,
            ProductName = source.ProductName,
            UnitPrice = source.UnitPrice
        };
    }

    public List<GetProductsQueryResult> MapList(List<Product> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}

// Entity → GetByIdResult Mapper
public class ProductToByIdResultMapper : ICustomMapper<Product, GetProductByIdQueryResult>
{
    public GetProductByIdQueryResult Map(Product source)
    {
        return new GetProductByIdQueryResult
        {
            Id = source.Id,
            ProductName = source.ProductName,
            UnitPrice = source.UnitPrice
        };
    }

    public List<GetProductByIdQueryResult> MapList(List<Product> sources)
    {
        return sources.Select(x => Map(x)).ToList();
    }
}
