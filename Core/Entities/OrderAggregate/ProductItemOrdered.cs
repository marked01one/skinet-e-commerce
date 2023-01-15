using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.OrderAggregate
{
  // Allows us to take a snapshot of the ordered ProductItem 
  public class ProductItemOrdered
  {
    // Parameterless constructor for migration purposes
    public ProductItemOrdered()
    {
    }

    public ProductItemOrdered(int id, string productName, string pictureUrl)
    {
      Id = id;
      ProductName = productName;
      PictureUrl = pictureUrl;
    }

    public int Id { get; set; } 
    public string ProductName { get; set; }
    public string PictureUrl { get; set; }   
  }
}