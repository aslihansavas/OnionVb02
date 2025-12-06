using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileModify;

public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, CreateAppUserProfileCommandResult>
{
    private readonly IAppUserProfileRepository _repository;
    private readonly ICustomMapper<CreateAppUserProfileCommand, AppUserProfile> _mapper;

    public CreateAppUserProfileCommandHandler(
        IAppUserProfileRepository repository,
        ICustomMapper<CreateAppUserProfileCommand, AppUserProfile> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateAppUserProfileCommandResult> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
    {
        AppUserProfile profile = _mapper.Map(request);
        await _repository.CreateAsync(profile);
        
        return new CreateAppUserProfileCommandResult
        {
            Id = profile.Id,
            IsSuccess = true,
            Message = "Kullanıcı Profili Oluşturuldu"
        };
    }
}
