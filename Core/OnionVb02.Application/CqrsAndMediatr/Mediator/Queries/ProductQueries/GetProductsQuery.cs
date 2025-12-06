using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;

public class GetProductsQuery : IRequest<List<GetProductsQueryResult>>
{

}
