using System;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;

public class GetOrderDetailsQueryResult
{
   public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    
   
    public string ProductName { get; set; }      
    public decimal UnitPrice { get; set; }       
    public string ShippingAddress { get; set; }

}
