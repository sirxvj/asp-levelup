using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
[Route("/api/[controller]")]
[ApiController]
public class OrderController:ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}/items")]
    public async Task<ActionResult<IEnumerable<OrderItemsDto>>> GetOrderItems([FromRoute]long id)
    {
        return Ok(await _orderService.GetOrderItems(id));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById([FromRoute]long id)
    {
        return Ok(await _orderService.GetOrderById(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody]OrderDto order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _orderService.AddOrder(order);
        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteOrder(long id)
    {
        await _orderService.DeleteOrder(id);
        return Ok();
    }
}