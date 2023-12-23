using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

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
        return Ok(await _brandService.GetBrands());
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> PutBrand([FromRoute] int id, [FromBody]BrandDto brand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _brandService.PutBrand(id, brand);
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<BrandDto>> BrandById([FromRoute] int id)
    {
        return await _brandService.GetBrandById(id);
    }

    [HttpPost]
    public async Task<ActionResult> AddBrand([FromBody]BrandDto brand)
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