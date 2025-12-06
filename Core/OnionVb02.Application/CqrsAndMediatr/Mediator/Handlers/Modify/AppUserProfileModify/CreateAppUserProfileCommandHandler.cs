using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileModify;

public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, CreateAppUserProfileCommandResult>
{
    private readonly IAppUserProfileRepository _repository;

    public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateAppUserProfileCommandResult> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
    {
        AppUserProfile appUserProfile=new AppUserProfile()
        {
            AppUserId=request.AppUserId,
            FirstName=request.FirstName,
            LastName=request.LastName,
            CreatedDate=DateTime.Now,
            Status=Domain.Enums.DataStatus.Inserted

        };
        await _repository.CreateAsync(appUserProfile);
        return new CreateAppUserProfileCommandResult
        {
            Id=appUserProfile.Id,
            IsSuccess=true,
            Message="Kullanıcı Oluşturuldu"
            


        };
    }
}
