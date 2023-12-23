using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface ICartItemService
{
    public Task<IEnumerable<CartItemDto>> GetByUserId(int userId);
    public Task AddCartItem(CartItemDto cartItem);
    public Task DeleteCartItemByIds(int userId,long productVariantId);
}