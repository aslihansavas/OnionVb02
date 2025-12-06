using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

public class CreateProductCommandResult :BaseCommandResult
{
    public int Id { get; set; }
}
