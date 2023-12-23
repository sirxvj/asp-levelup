using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IOrderTransactionService
{
    public Task<IEnumerable<OrderTransactionDto>> GetByOrderId(long id);
    public Task AddOrderTransaction(OrderTransactionDto orderTransaction);
    
}