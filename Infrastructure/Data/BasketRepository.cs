using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
  public class BasketRepository : IBasketRepository
  {
    private readonly IDatabase _database;
    public BasketRepository(IConnectionMultiplexer redis)
    {
      _database = redis.GetDatabase();
    }

    public async Task<bool> DeleteBasketAsync(string basketId)
    {
      return await _database.KeyDeleteAsync(basketId);
    }

    /*
    Data are as strings in Redis
    Object from client --> serialize it to string for Redis --> deserialize it to JSON for use in API
    */
    public async Task<CustomerBasket> GetBasketAsync(string basketId)
    {
      var data = await _database.StringGetAsync(basketId);
      // Return deserialized data if there is data, otherwise return null
      return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public Task<CustomerBasket> UpdateBasketAsync(string basketId)
    {
      throw new NotImplementedException();
    }

    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
    {
      // Replace the existing Redis string with the new version
      var created = await _database.StringSetAsync(basket.Id, 
        JsonSerializer.Serialize(basket), TimeSpan.FromDays(30)
      );

      return (!created) ? null : await GetBasketAsync(basket.Id);
    }
  }
}