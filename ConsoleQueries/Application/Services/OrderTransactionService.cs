using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class OrderTransactionService:IOrderTransactionService
{
    private readonly DataBaseContext _dbc;

    public OrderTransactionService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<IEnumerable<OrderTransactionDto>> GetByOrderId(long id)
    {
        return (await _dbc.OrderTransactions.Where(t => t.OrderId == id).ToListAsync()).Adapt<IEnumerable<OrderTransactionDto>>();
    }

    public async Task AddOrderTransaction(OrderTransactionDto orderTransaction)
    {
        _dbc.Add(orderTransaction);
        await _dbc.SaveChangesAsync();
    }
}