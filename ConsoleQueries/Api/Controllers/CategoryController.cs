using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
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
        return Ok(await _categoryService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetById([FromRoute]int id)
    {
        return Ok(await _categoryService.GetById(id));
    }

    
    
    [HttpPost]
    public async Task<ActionResult> AddCategory([FromBody]CategoryDto category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _categoryService.AddCategory(category);
        return Ok();
    }

    [HttpPut("{id}/section/{sectionId}")]
    public async Task LinkToSection([FromRoute]int id,[FromRoute]int sectionId)
    {
        await _categoryService.LinkToSection(id, sectionId);
    }
}