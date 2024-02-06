using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
[Route("/api/[controller]")]
[ApiController]
public class ProductVariantController:ControllerBase
{
    private readonly IProductVariantService _productService;

    public ProductVariantController(IProductVariantService productService)
    {
        _productService = productService;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductVariantDto>> GetById([FromRoute] int id)
    {
        return Ok(await _productService.GetProductVariantById(id));
    }
    
}