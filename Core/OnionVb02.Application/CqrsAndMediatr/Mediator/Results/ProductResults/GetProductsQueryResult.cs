using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;

public class GetProductsQueryResult
{
    public int Id { get; set; }
    public string ProductName { get; set;}
    public decimal UnitPrice { get; set; }
}
