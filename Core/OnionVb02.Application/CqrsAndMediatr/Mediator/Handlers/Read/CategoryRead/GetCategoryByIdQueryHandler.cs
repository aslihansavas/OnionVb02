using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.CategoryRead;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
{
    private readonly ICategoryRepository _repository;
    private readonly ICustomMapper<Category, GetCategoryByIdResult> _mapper;

    public GetCategoryByIdQueryHandler(
        ICategoryRepository repository,
        ICustomMapper<Category, GetCategoryByIdResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCategoryByIdResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        Category category = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map(category);
    }
}
