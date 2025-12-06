using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

public class CreateOrderCommandResult :BaseCommandResult
{
    public int Id { get; set; }
}
