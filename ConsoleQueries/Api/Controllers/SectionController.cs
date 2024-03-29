using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
[Route("/api/[controller]")]
[ApiController]
public class SectionController:ControllerBase
{
    private readonly ISectionService _sectionService;

    public SectionController(ISectionService sectionService)
    {
        _sectionService = sectionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SectionDto>>> GetAllSections()
    {
        return Ok((await _sectionService.GetSections()).Adapt<IEnumerable<SectionDto>>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SectionDto>> GetSectionById([FromRoute]int id)
    {
        return Ok((await _sectionService.GetSectionById(id)).Adapt<SectionDto>());
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/name/{name}")]
    public async Task<ActionResult> ChangeName([FromRoute] short id, [FromRoute] string name)
    {
        await _sectionService.ChangeName(id, name);
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult> NewSection([FromBody]SectionDto section)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _sectionService.AddSection(section);
        return Ok();
    }
    
}