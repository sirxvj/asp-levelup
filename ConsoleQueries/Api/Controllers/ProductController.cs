using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id)
    {
        return Ok(await _productService.GetById(id));
    }

    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategory([FromRoute]int categoryId)
    {
        return Ok(await _productService.GetCategoryProducts(categoryId));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct([FromRoute]int id,[FromBody] ProductDto product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _productService.UpdateProduct(id,product);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> NewProduct([FromBody] ProductDto product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _productService.AddProduct(product);
        return Ok();
    }
    
}