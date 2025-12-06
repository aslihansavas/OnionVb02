using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;

public class GetOrderByIdQueryResult
{
    public int Id { get; set; }
    public string ShippingAdresss { get; set; }
}
