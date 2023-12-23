using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api")]
[ApiController]
public class CartItemController:ControllerBase
{
    private readonly ICartItemService _cartItemService;

    public CartItemController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }
    
    [HttpGet("{id}")] //userid
    public async Task<ActionResult<CartItemDto>> GetCartItemByUserId([FromRoute]int id)
    {
        return Ok(await _cartItemService.GetByUserId(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddCartItem([FromBody]CartItemDto cartItem)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _cartItemService.AddCartItem(cartItem);
        return Ok();
    }

    [HttpDelete("user/{userId}/pv/{productVariantId}")]
    public async Task<ActionResult> DeleteCartItem([FromRoute]int userId,[FromRoute]long productVariantId)
    {
        await _cartItemService.DeleteCartItemByIds(userId, productVariantId);
        return Ok();
    }
    
}