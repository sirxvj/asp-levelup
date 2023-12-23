using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api")]
[ApiController]
public class SizeController:ControllerBase
{
    private readonly ISizeService _sizeService;

    public SizeController(ISizeService sizeService)
    {
        _sizeService = sizeService;
    }

    [HttpGet]
    public async Task<ActionResult<SizeDto>> GetAll()
    {
        return Ok(await _sizeService.GetSizes());
    }

    [HttpPost]
    public async Task<ActionResult> AddSize([FromBody]SizeDto size)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _sizeService.AddSize(size);
        return Ok();
    }
}