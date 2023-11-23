using ConsoleQueries.Models;

namespace ConsoleQueries.Data.Repository;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetBrands();
    Task PutBrand(int id,string name);
    Task<Brand?> GetBrandById(int id);
    Task AddBrand(string name);
    Task DeleteBrand(int id);
}