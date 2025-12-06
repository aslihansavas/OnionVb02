using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.ProductRead;

public class GetProductQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsQueryResult>>
{
    private readonly IProductRepository _repository;
    private readonly ICustomMapper<Product, GetProductsQueryResult> _mapper;

    public GetProductQueryHandler(
        IProductRepository repository,
        ICustomMapper<Product, GetProductsQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product> products = await _repository.GetAllAsync();
        return _mapper.MapList(products);  // Mapper kullanıyoruz! ✨
    }
}
