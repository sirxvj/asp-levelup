using ConsoleQueries.Data;
using ConsoleQueries.Data.Repository;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Domain;

public class BrandService:IBrandService
{
    private DataBaseContext _dataBase;
    public BrandService(DataBaseContext dbc)
    {
        _dataBase = dbc;
    }
    public async Task<IEnumerable<Brand>> GetBrands()
    {
        return await _dataBase.Brands.ToListAsync();
    }

    public async Task PutBrand(int id, string name)
    {
        var item = await _dataBase.Brands.FirstOrDefaultAsync(b => b.Id == id);
        if (item is not null)
        {
            item.Name = name;
        }
        await _dataBase.SaveChangesAsync();
    }

    public async Task<Brand?> GetBrandById(int id)
    {
        return await _dataBase.Brands.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddBrand(string name)
    {
        Brand newbrand = new Brand();
        newbrand.Name = name;
        await _dataBase.AddAsync(newbrand);
        await _dataBase.SaveChangesAsync();
    }

    public async Task DeleteBrand(int id)
    {
        var brand = await _dataBase.Brands.FirstOrDefaultAsync(b => b.Id == id);
        if(brand is not null)_dataBase.Brands.Remove(brand);
        await _dataBase.SaveChangesAsync();
    }
}