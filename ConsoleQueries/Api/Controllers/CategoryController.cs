using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class CategoryController:ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var result = await _categoryService.GetAll();
        return Ok(result.Adapt<IEnumerable<CategoryDto>>());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetById([FromRoute]int id)
    {
        return Ok((await _categoryService.GetById(id)).Adapt<CategoryDto>());
    }

    
    
    [HttpPost]
    public async Task<ActionResult> AddCategory([FromBody]Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _categoryService.AddCategory(category);
        return Ok();
    }

    [HttpPut("{id}/section/{section_id}")]
    public async Task PutToSection([FromRoute]int id,[FromRoute]int section_id)
    {
        await _categoryService.PutToSection(id, section_id);
    }
}