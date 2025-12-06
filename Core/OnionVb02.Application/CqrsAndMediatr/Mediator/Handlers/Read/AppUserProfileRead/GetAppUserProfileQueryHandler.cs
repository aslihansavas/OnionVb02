using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserProfileRead;

public class GetAppUserProfileQueryHandler : IRequestHandler<GetAppUserProfileQuery, List<GetAppUserProfileQueryResult>>
{
    private readonly IAppUserProfileRepository _repository;
    private readonly ICustomMapper<AppUserProfile, GetAppUserProfileQueryResult> _mapper;

    public GetAppUserProfileQueryHandler(
        IAppUserProfileRepository repository,
        ICustomMapper<AppUserProfile, GetAppUserProfileQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetAppUserProfileQueryResult>> Handle(GetAppUserProfileQuery request, CancellationToken cancellationToken)
    {
        List<AppUserProfile> values = await _repository.GetAllAsync();
        return _mapper.MapList(values);
    }
}
