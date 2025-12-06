using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.ProductRead;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    private readonly IProductRepository _repository;
    private readonly ICustomMapper<Product, GetProductByIdQueryResult> _mapper;

    public GetProductByIdQueryHandler(
        IProductRepository repository,
        ICustomMapper<Product, GetProductByIdQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product product = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map(product);  // Mapper kullanıyoruz! ✨
    }
}
