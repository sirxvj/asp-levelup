using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class ProductVariantService:IProductVariantService
{
    private readonly DataBaseContext _dbc;

    public ProductVariantService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<IEnumerable<ProductVariantDto>> GetProductVariantByProductId(long id)
    {
        return (await _dbc.ProductVariants.Where(p => p.ProductId == id).ToListAsync()).Adapt<IEnumerable<ProductVariantDto>>();
    }

    public async Task<ProductVariantDto> GetProductVariantById(long id)
    {
        return (await _dbc.ProductVariants.Where(p => p.Id == id).ToListAsync()).Adapt<ProductVariantDto>();
    }

    public Task EditProductVariant(long id, ProductVariantDto productVar)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductVariant(long id)
    {
        throw new NotImplementedException();
    }
}