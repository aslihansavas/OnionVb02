using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserRead;

public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
{
    private readonly IAppUserRepository _repository;
    private readonly ICustomMapper<AppUser, GetAppUserQueryResult> _mapper;

    public GetAppUserQueryHandler(
        IAppUserRepository repository,
        ICustomMapper<AppUser, GetAppUserQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
    {
        List<AppUser> values = await _repository.GetAllAsync();
        return _mapper.MapList(values);
    }
}
