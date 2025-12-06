using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;

public class GetAppUserProfileQuery :IRequest<List<GetAppUserProfileQueryResult>>
{

}
