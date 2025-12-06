using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.AppUserRead;

public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
{
    private readonly IAppUserRepository _repository;
    private readonly ICustomMapper<AppUser, GetAppUserByIdQueryResult> _mapper;

    public GetAppUserByIdQueryHandler(
        IAppUserRepository repository,
        ICustomMapper<AppUser, GetAppUserByIdQueryResult> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
    {
        AppUser value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map(value);
    }
}
