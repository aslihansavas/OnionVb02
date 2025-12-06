using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;

public class GetOrdersQuery :IRequest<List<GetOrdersQueryResult>>
{

}
