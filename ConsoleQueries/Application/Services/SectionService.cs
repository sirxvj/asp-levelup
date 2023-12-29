using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class SectionService:ISectionService
{
    private readonly DataBaseContext _dataBase;

    public SectionService(DataBaseContext dbc)
    {
        _dataBase = dbc;
    }
    public async Task<IEnumerable<SectionDto>> GetSections()
    {
        return (await _dataBase.Sections
            .ToListAsync())
            .Adapt<IEnumerable<SectionDto>>();
    }

    public async Task<SectionDto> GetSectionById(int id)
    {
        return (await _dataBase.Sections
            .Where(s => s.Id==id)
            .FirstAsync())
            .Adapt<SectionDto>();
    }

    public async Task AddSection(SectionDto section)
    {
        _dataBase.Add(section);
        await _dataBase.SaveChangesAsync();
    }

    public async Task ChangeName(short id, string name)
    {
        var changed = await _dataBase.Sections.Where(s => s.Id == id).FirstAsync();
        changed.Name = name;
        await _dataBase.SaveChangesAsync();
    }
}