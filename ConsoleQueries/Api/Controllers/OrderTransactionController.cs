using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class OrderTransactionController:ControllerBase
{
    private readonly IOrderTransactionService _orderTransaction;

    public OrderTransactionController(IOrderTransactionService orderTransaction)
    {
        _orderTransaction = orderTransaction;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<OrderTransactionDto>>> GetByOrderId([FromRoute] long id)
    {
        return Ok(await _orderTransaction.GetByOrderId(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddOrderTransaction([FromBody]OrderTransactionDto transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _orderTransaction.AddOrderTransaction(transaction);
        return Ok();
    }
}