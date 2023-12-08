using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api;

[Route("/api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService bs)
    {
        _brandService = bs;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BrandDto>>> Brands() 
    {
        var brands =  await _brandService.GetBrands();
        return Ok(brands.Adapt<IEnumerable<BrandDto>>());
    }
    [HttpPut("/{id}/name/{name}")]
    public async Task<ActionResult> PutBrand([FromRoute] int id, [FromRoute]string name)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _brandService.PutBrand(id, name);
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<BrandDto>> BrandById([FromRoute] int id)
    {
        Brand? brand = await _brandService.GetBrandById(id);
        return brand.Adapt<BrandDto>();
    }

    [HttpPost]
    public async Task<ActionResult> NewBrand([FromBody]Brand brand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _brandService.AddBrand(brand);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBrand([FromRoute]int id)
    {
        await _brandService.DeleteBrand(id);
        return Ok();
    }
}