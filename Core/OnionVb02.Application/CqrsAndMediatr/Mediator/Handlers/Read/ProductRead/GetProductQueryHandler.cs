using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.ProductRead;

public class GetProductQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsQueryResult>>
{
    private readonly IProductRepository _repository;

    public GetProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = await _repository.GetAllAsync();
        return products.Select(x=>new GetProductsQueryResult
        {
            ProductName=x.ProductName,
            UnitPrice=x.UnitPrice,
            
        }).ToList();
    }
}
