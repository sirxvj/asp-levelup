using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class OrderService:IOrderService
{
    private readonly DataBaseContext _dbc;

    public OrderService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<OrderDto> GetOrderById(long id)
    {
        return (await _dbc.Orders.Where(o => o.Id == id).FirstOrDefaultAsync()).Adapt<OrderDto>();
    }

    public async Task<IEnumerable<OrderItemsDto>> GetOrderItems(long id)
    {
        return (await _dbc.OrderItems.Where(o => o.OrderId == id).FirstOrDefaultAsync()).Adapt<IEnumerable<OrderItemsDto>>();
    }

    public async Task AddOrder(OrderDto order)
    {
        _dbc.Add(order);
        await _dbc.SaveChangesAsync();
    }

    public async Task DeleteOrder(long id)
    {
        var item = _dbc.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
        _dbc.Remove(item);
        await _dbc.SaveChangesAsync();
    }
}