using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IProductService
{
    Task<ProductDto> GetById(int id);
    Task<IEnumerable<ProductDto>> GetCategoryProducts(int cId);
    Task UpdateProduct(int id, ProductDto product);
    Task AddProduct(ProductDto product);
}