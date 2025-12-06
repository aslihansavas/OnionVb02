using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;

public class GetOrderDetailsQuery :IRequest<List<GetOrderDetailsQueryResult>>
{

}
