using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserProfileRead;

public class GetAppUserProfileByIdQueryHandler : IRequestHandler<GetAppUserProfileByIdQuery, GetAppUserProfileByIdQueryResult>
{
    private readonly IAppUserProfileRepository _repository;
    private readonly ICustomMapper<AppUserProfile, GetAppUserProfileByIdQueryResult> _mapper;

    public GetAppUserProfileByIdQueryHandler(
        IAppUserProfileRepository repository,
        ICustomMapper<AppUserProfile, GetAppUserProfileByIdQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        AppUserProfile profile = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map(profile);
    }
}
