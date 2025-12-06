using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;

public class CreateAppUserProfileCommandResult
{
    public int Id { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    

}
