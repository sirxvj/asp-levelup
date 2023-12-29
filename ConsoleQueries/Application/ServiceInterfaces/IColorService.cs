using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IColorService
{
    public Task<IEnumerable<ColorDto>> GetColors();
    public Task AddColor(ColorDto? color);

}