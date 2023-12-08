using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Domain.Services;

public class ProductService:IProductService
{
    private readonly DataBaseContext _dbc;

    public ProductService(DataBaseContext dbc)
    {
        this._dbc = dbc;
    }

    public async Task<Product> GetById(int id)
    {
        return await _dbc.Products.Where(p => p.Id == id).FirstAsync();
    }

    public async Task<IEnumerable<Product>> GetCategoryProducts(int cId)
    {
        var products = await _dbc.Products.Where(p => p.CategoryId==cId).ToListAsync();
        return products;
    }

    public async Task UpdateProduct(int id, Product product)
    {
        var changed = await _dbc.Products.Where(p => p.Id == id).FirstAsync();
        changed.CategoryId = product.CategoryId;
        changed.Name = product.Name;
        changed.Price = product.Price;
        changed.BrandId = product.BrandId;
        changed.AverageRating = product.AverageRating;
        await _dbc.SaveChangesAsync();
    }

    public async Task AddProduct(Product product)
    {
        await _dbc.Products.AddAsync(product);
        await _dbc.SaveChangesAsync();
    }

    
}