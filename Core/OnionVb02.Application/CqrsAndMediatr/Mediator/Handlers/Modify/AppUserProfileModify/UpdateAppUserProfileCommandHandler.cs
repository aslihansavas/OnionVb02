using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileModify;

public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand, UpdateAppUserProfileCommandResult>
{
    private readonly IAppUserProfileRepository _repository;

    public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateAppUserProfileCommandResult> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
    {
        AppUserProfile profile = await _repository.GetByIdAsync(request.Id);
        profile.FirstName = request.FirstName;
        profile.LastName = request.LastName;
        profile.Status=Domain.Enums.DataStatus.Updated;
        profile.UpdatedDate = DateTime.Now;

        await _repository.SaveChangesAsync();

        return new UpdateAppUserProfileCommandResult
        {
            IsSucces=true,
            Message="Profil Güncellendi"
        };
    }
    
}
