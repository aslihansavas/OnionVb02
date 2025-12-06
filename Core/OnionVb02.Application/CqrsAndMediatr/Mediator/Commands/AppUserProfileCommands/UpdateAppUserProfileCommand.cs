using System;
using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;

public class UpdateAppUserProfileCommand :IRequest<UpdateAppUserProfileCommandResult>
{
     public int Id { get; set; }  
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
