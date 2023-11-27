using ConsoleQueries.Models;

namespace ConsoleQueries.Domain;

public interface IBrandService
{
    Task<IEnumerable<Brand>> GetBrands();
    Task PutBrand(int id,string name);
    Task<Brand?> GetBrandById(int id);
    Task AddBrand(string name);
    Task DeleteBrand(int id);
}