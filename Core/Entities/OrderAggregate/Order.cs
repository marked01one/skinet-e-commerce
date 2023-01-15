using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
  public class Order : BaseEntity
  {
    // Parameterless constructor for migration purposes
    public Order()
    {
    }

    public Order(
      IReadOnlyList<OrderItem> orderItems,
      string buyerEmail, 
      Address shipToAddress, 
      DeliveryMethod deliveryMethod, 
      decimal subtotal
    )
    {
      BuyerEmail = buyerEmail;
      ShipToAddress = shipToAddress;
      DeliveryMethod = deliveryMethod;
      OrderItems = orderItems;
      Subtotal = subtotal;
    }

    public string BuyerEmail { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public Address ShipToAddress { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; }
    public IReadOnlyList<OrderItem> OrderItems { get; set; }
    public decimal Subtotal { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string PaymentIntentId { get; set; }


    // AutoMapper will automatically map whatever function prefixed with "Get"
    // i.e. Get[Property Name]() will be executed and its return value applied to [Property Name]
    public decimal GetTotal()
    {
      return Subtotal + DeliveryMethod.Price;
    }
  }
}