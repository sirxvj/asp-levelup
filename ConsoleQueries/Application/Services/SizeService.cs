using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class SizeService:ISizeService
{
    private readonly DataBaseContext _dbc;

    public SizeService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }
    
    public async Task<IEnumerable<SizeDto>> GetSizes()
    {
        return (await _dbc.Sizes.ToListAsync()).Adapt<IEnumerable<SizeDto>>();
    }

    public async Task AddSize(SizeDto? size)
    {
        _dbc.Sizes.Add(size.Adapt<Size>());
        await _dbc.SaveChangesAsync();
    }
}