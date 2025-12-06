using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserModify;

public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreateAppUserCommandResult>
{
    private readonly IAppUserRepository _repository;
    private readonly ICustomMapper<CreateAppUserCommand, AppUser> _mapper;

    public CreateAppUserCommandHandler(
        IAppUserRepository repository,
        ICustomMapper<CreateAppUserCommand, AppUser> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateAppUserCommandResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
    {
        AppUser appUser = _mapper.Map(request);
        await _repository.CreateAsync(appUser);
        
        return new CreateAppUserCommandResult
        {
            IsSuccess = true,
            Message = "Kullanıcı Oluşturuldu"
        };
    }
}
