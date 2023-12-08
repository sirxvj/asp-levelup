using ConsoleQueries.Api.DTOs;
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
        var product = await _productService.GetById(id);
        return Ok(product.Adapt<ProductDto>());
    }

    [HttpGet("category/{cId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategory([FromRoute]int cId)
    {
        var products = await _productService.GetCategoryProducts(cId);
        return Ok(products.Adapt<IEnumerable<ProductDto>>());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct([FromRoute]int id,[FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _productService.UpdateProduct(id,product);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> NewProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _productService.AddProduct(product);
        return Ok();
    }
    
}