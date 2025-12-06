using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries;

public class GetCategoryByIdQuery :IRequest<GetCategoryByIdQueryResult>
{
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}
