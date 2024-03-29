﻿using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
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
    [Authorize(Roles = "Admin")]
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
    public async Task<ActionResult<BrandDto?>> BrandById([FromRoute] int id)
    {
        return Ok(await _brandService.GetBrandById(id));
    }
    [Authorize(Roles = "Admin")]
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
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBrand([FromRoute]int id)
    {
        await _brandService.DeleteBrand(id);
        return Ok();
    }
}