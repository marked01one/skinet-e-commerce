using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
  
  public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
  {
    // Getting a list of orders
    public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
    {
      AddInclude(o => o.OrderItems);
      AddInclude(o => o.DeliveryMethod);
      AddOrderByDescending(o => o.OrderDate);
    }

    // Getting an individual order
    public OrdersWithItemsAndOrderingSpecification(int id, string email) 
      : base(o => o.Id == id && o.BuyerEmail == email)
    {
      AddInclude(o => o.OrderItems);
      AddInclude(o => o.DeliveryMethod);
    }
  }
}