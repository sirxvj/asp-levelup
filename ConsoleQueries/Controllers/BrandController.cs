using ConsoleQueries.Data;
using ConsoleQueries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Controllers;

public class BrandController : Controller
{
    private readonly DataBaseContext _dbcontext;

    public BrandController(DataBaseContext dbc)
    {
        _dbcontext = dbc;
    }
    [HttpGet]
    public async Task<string> Brands() 
    {
        string res = "";
        var brands = await _dbcontext.Brands.ToListAsync();
        foreach (var b in brands)
        {
            res += b.Id + " " + b.Name + "\n";
        }
        return res;
    }
    [HttpPut]
    public async Task<IActionResult> PutBrand([FromQuery(Name = "id")] int id, [FromQuery(Name="name")]string name)
    {
        var item = await _dbcontext.Brands.FirstOrDefaultAsync(b => b.Id == id);
        if (item is not null)
        {
            item.Name = name;
        }
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _dbcontext.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("/brand/brandbyid/{id?}")]
    public async Task<string> BrandById([FromQuery(Name = "id")] int id)
    {
        Brand? brand = await _dbcontext.Brands.FirstOrDefaultAsync(b => b.Id == id);
        return brand.Id + " " + brand.Name;
    }

    [HttpPost]
    public async Task<IActionResult> NewBrand([FromQuery(Name = "name")]string name)
    {
        Brand newbrand = new Brand();
        newbrand.Name = name;
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _dbcontext.AddAsync(newbrand);
        await _dbcontext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task DeleteBrand([FromQuery(Name = "id")]int id)
    {
        var brand = await _dbcontext.Brands.FirstOrDefaultAsync(b => b.Id == id);
        if(!(brand is null))_dbcontext.Brands.Remove(brand);
        await _dbcontext.SaveChangesAsync();
    }
}