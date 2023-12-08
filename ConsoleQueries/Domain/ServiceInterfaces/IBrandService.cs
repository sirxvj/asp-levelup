using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.ServiceInterfaces;

public interface IBrandService
{
    Task<IEnumerable<Brand>> GetBrands();
    Task PutBrand(int id,string name);
    Task<Brand?> GetBrandById(int id);
    Task AddBrand(Brand brand);
    Task DeleteBrand(int id);
}