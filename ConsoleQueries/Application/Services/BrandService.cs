using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class BrandService:IBrandService
{
    private readonly DataBaseContext _dataBase;
    public BrandService(DataBaseContext dbc)
    {
        _dataBase = dbc;
    }
    public async Task<IEnumerable<BrandDto>> GetBrands()
    {
        return (await _dataBase.Brands.ToListAsync()).Adapt<IEnumerable<BrandDto>>();
    }

    public async Task PutBrand(int id, BrandDto brand)
    {
        var item = await _dataBase.Brands.FirstOrDefaultAsync(b => b.Id == id);
        if (item is not null)
        {
            item.Name = brand.Name;
        }
        await _dataBase.SaveChangesAsync();
    }

    public async Task<BrandDto> GetBrandById(int id)
    {
        return (await _dataBase.Brands.FirstOrDefaultAsync(b => b.Id == id)).Adapt<BrandDto>();
    }

    public async Task AddBrand(BrandDto brand)
    {
        _dataBase.Add(brand.Adapt<Brand>());
        await _dataBase.SaveChangesAsync();
    }

    public async Task DeleteBrand(int id)
    {
        var brand = await _dataBase.Brands.FirstOrDefaultAsync(b => b.Id == id);
        if(brand is not null) _dataBase.Brands.Remove(brand);
        await _dataBase.SaveChangesAsync();
    }
}