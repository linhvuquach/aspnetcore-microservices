using System.Text.Json;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Repositories;

public class BasketRepository : IBasketRepository
{
  private readonly IDistributedCache _redisCache;

  public BasketRepository(IDistributedCache redisCache)
  {
    _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
  }

  public async Task<ShoppingCart> GetBasket(string userName)
  {
    var basket = await _redisCache.GetStringAsync(userName);
    if (basket is null) return null;

    return JsonSerializer.Deserialize<ShoppingCart>(basket);
  }

  public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
  {
    await _redisCache.SetStringAsync(basket.Username, JsonSerializer.Serialize<ShoppingCart>(basket));
    return await GetBasket(basket.Username);
  }

  public async Task DeleteBasket(string userName)
  {
    await _redisCache.RemoveAsync(userName);

  }
}
