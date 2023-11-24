using ConsoleQueries.Data;
using ConsoleQueries.Domain;
using ConsoleQueries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Controllers;

public class BrandController : Controller
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService bs)
    {
        _brandService = bs;
    }
    [HttpGet("/brand/brands")]
    public async Task<string> Brands() 
    {
        string res = "";
        var brands =  _brandService.GetBrands().Result;
        foreach (var b in brands)
        {
            res += b.Id + " " + b.Name + "\n";
        }
        return res;
    }
    [HttpPut("/brand/putbrand/{id}")]
    public async Task<IActionResult> PutBrand([FromRoute] int id, [FromQuery(Name="name")]string name)
    {
        await _brandService.PutBrand(id, name);
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return Ok();
    }
    [HttpGet("/brand/brandbyid/{id?}")]
    public async Task<string> BrandById([FromQuery(Name = "id")] int id)
    {
        Brand? brand = await _brandService.GetBrandById(id);
        return brand is null ?"null":brand.Id + " " + brand.Name;
    }

    [HttpPost("brand/newbrand")]
    public async Task<IActionResult> NewBrand([FromQuery(Name = "name")]string name)
    {
        await _brandService.AddBrand(name);
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("/brand/deletebrand")]
    public async Task DeleteBrand([FromQuery(Name = "id")]int id)
    {
        await _brandService.DeleteBrand(id);
    }
}