using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IBrandService
{
    Task<IEnumerable<BrandDto>> GetBrands();
    Task PutBrand(int id,BrandDto brand);
    Task<BrandDto> GetBrandById(int id);
    Task AddBrand(BrandDto? brand);
    Task DeleteBrand(int id);
}