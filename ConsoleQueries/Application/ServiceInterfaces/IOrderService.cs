using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IOrderService
{
    public Task<OrderDto> GetOrderById(long id);
    public Task<IEnumerable<OrderItemsDto>> GetOrderItems(long id);
    public Task AddOrder(OrderDto order);
    public Task DeleteOrder(long id);
}