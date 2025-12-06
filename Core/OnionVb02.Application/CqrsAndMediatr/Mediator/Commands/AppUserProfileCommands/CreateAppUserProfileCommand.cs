using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;

public class CreateAppUserProfileCommand : IRequest<CreateAppUserProfileCommandResult>
{   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int AppUserId { get; set; }
}
