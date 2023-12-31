using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
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

    [Authorize(Roles = "Admin")]
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

    [Authorize(Roles = "Admin")]
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