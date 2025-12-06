using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

public class CreateOrderDetailCommandResult :BaseCommandResult
{
    public int Id { get; set; }
}
