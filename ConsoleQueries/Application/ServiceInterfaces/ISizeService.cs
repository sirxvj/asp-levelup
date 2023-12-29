using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface ISizeService
{
    Task<IEnumerable<SizeDto>> GetSizes();
    Task AddSize(SizeDto? size);
}