using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.ServiceInterfaces;

public interface IProductService
{
    Task<Product> GetById(int id);
    Task<IEnumerable<Product>> GetCategoryProducts(int cId);
    Task UpdateProduct(int id, Product product);
    Task AddProduct(Product product);
}