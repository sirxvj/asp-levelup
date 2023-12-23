using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api")]
[ApiController]
public class ColorController:ControllerBase
{
    private readonly IColorService _colorService;

    public ColorController(IColorService colorService)
    {
        _colorService = colorService;
    }

    [HttpGet]
    public async Task<ActionResult<SizeDto>> GetAll()
    {
        return Ok(await _colorService.GetColors());
    }

    [HttpPost]
    public async Task<ActionResult> AddColor([FromBody]ColorDto color)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _colorService.AddColor(color);
        return Ok();
    }
    
}