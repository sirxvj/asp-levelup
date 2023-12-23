using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class CartItemService:ICartItemService
{
    private readonly DataBaseContext _dbc;

    public CartItemService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<IEnumerable<CartItemDto>> GetByUserId(int id)
    {
        return (await _dbc.CartItems.Where(i => i.UserId == id).ToListAsync()).Adapt<IEnumerable<CartItemDto>>();
    }

    public async Task AddCartItem(CartItemDto cartItem)
    {
        _dbc.CartItems.Add(cartItem.Adapt<CartItem>());
        await _dbc.SaveChangesAsync();
    }

    public async Task DeleteCartItemByIds(int userId,long productVariantId)
    {
        var item = _dbc.CartItems.Where(i => i.UserId == userId && i.ProductVariantId == productVariantId).FirstAsync();
        _dbc.Remove(item);
        await _dbc.SaveChangesAsync();
    }
}