using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _basketRepository;
    private readonly DiscountGrpcservice _discountGrpcservice;

    public BasketController(IBasketRepository basketRepository, DiscountGrpcservice discountGrpcservice)
    {
        _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        _discountGrpcservice = discountGrpcservice ?? throw new ArgumentNullException(nameof(discountGrpcservice));
    }

    [HttpGet("userName", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
    {
        var basket = await _basketRepository.GetBasket(userName);
        return Ok(basket ?? new ShoppingCart(userName));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
    {
        foreach (var item in basket.Items)
        {
            var coupon = await _discountGrpcservice.GetDiscount(item.ProductName);
            item.Price -= coupon.Amount;
        }

        return Ok(await _basketRepository.UpdateBasket(basket));
    }

    [HttpDelete("userName", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteBasket(string userName)
    {
        await _basketRepository.DeleteBasket(userName);
        return Ok();
    }
}
