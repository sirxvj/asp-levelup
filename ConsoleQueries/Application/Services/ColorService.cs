using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class ColorService:IColorService
{
    private readonly DataBaseContext _dbc;

    public ColorService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<IEnumerable<ColorDto>> GetColors()
    {
        return (await _dbc.Colors.ToListAsync()).Adapt<IEnumerable<ColorDto>>();
    }

    public async Task AddColor(ColorDto? color)
    {
        _dbc.Colors.Add(color.Adapt<Color>());
        await _dbc.SaveChangesAsync();
    }
}