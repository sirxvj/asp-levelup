using ConsoleQueries.Data.Repository;
using ConsoleQueries.Models;

namespace ConsoleQueries.Domain;

public class BrandService:IBrandService
{
    private readonly IBrandRepository _repository;
    public BrandService(IBrandRepository repo)
    {
        _repository = repo;
    }
    public Task<IEnumerable<Brand>> GetBrands()
    {
        return _repository.GetBrands();
    }

    public Task PutBrand(int id, string name)
    {
        return _repository.PutBrand(id, name);
    }

    public Task<Brand?> GetBrandById(int id)
    {
        return _repository.GetBrandById(id);
    }

    public Task AddBrand(string name)
    {
        return _repository.AddBrand(name);
    }

    public Task DeleteBrand(int id)
    {
        return _repository.DeleteBrand(id);
    }
}