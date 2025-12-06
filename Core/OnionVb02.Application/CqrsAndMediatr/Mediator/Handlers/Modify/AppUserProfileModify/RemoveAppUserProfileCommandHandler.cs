using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfileModify;

public class RemoveAppUserProfileCommandHandler : IRequestHandler<RemoveAppUserProfileCommand, RemoveAppUserProfileCommandResult>
{
    private readonly IAppUserProfileRepository _repository;
    public async Task<RemoveAppUserProfileCommandResult> Handle(RemoveAppUserProfileCommand request, CancellationToken cancellationToken)
    {
        AppUserProfile profile= await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(profile);
        return new RemoveAppUserProfileCommandResult
        {
           IsSucces=true,
           Message = "Profil Silindi."
        };
    }
}
