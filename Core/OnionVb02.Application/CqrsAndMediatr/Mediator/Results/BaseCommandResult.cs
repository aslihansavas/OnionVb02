using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results;

public abstract class BaseCommandResult
{
     public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
