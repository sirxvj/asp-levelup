using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IProductVariantService
{
    public Task<IEnumerable<ProductVariantDto>> GetProductVariantByProductId(long id);
    public Task<ProductVariantDto> GetProductVariantById(long id);
    public Task EditProductVariant(long id,ProductVariantDto productVar);
    public Task DeleteProductVariant(long id);
}