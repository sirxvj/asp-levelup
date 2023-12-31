using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class ProductService:IProductService
{
    private readonly DataBaseContext _dbc;

    public ProductService(DataBaseContext dbc)
    {
        this._dbc = dbc;
    }

    public async Task<ProductDto> GetById(int id)
    {
        return (await _dbc.Products.Where(p => p.Id == id).FirstOrDefaultAsync()).Adapt<ProductDto>();
    }

    public async Task<IEnumerable<ProductDto>> GetCategoryProducts(int cId)
    {
       return(await _dbc.Products
           .Where(p => p.CategoryId==cId)
           .ToListAsync())
           .Adapt<IEnumerable<ProductDto>>();
        
    }

    public async Task UpdateProduct(int id, ProductDto product)
    {
        var changed = await _dbc.Products.Where(p => p.Id == id).FirstAsync();
        changed.CategoryId = product.CategoryId;
        changed.Name = product.Name;
        changed.Price = product.Price;
        changed.BrandId = product.BrandId;
        changed.AverageRating = product.AverageRating;
        await _dbc.SaveChangesAsync();
    }

    public async Task AddProduct(ProductDto product)
    {
        _dbc.Products.Add(product.Adapt<Product>());
        await _dbc.SaveChangesAsync();
    }
}