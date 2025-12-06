using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.CategoryRead;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
{
    private readonly ICategoryRepository _repository;
    private readonly ICustomMapper<Category, GetCategoryQueryResult> _mapper;

    public GetCategoryQueryHandler(
        ICategoryRepository repository,
        ICustomMapper<Category, GetCategoryQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        List<Category> categories = await _repository.GetAllAsync();
        return _mapper.MapList(categories);
    }
}
