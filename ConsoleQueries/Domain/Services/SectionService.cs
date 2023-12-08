using ConsoleQueries.Data;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Domain.Services;

public class SectionService:ISectionService
{
    private readonly DataBaseContext _dataBase;

    public SectionService(DataBaseContext dbc)
    {
        _dataBase = dbc;
    }
    public async Task<IEnumerable<Section>> GetSections()
    {
        return await _dataBase.Sections.ToListAsync();
    }

    public async Task<Section> GetSectionById(int id)
    {
        return await _dataBase.Sections.Where(s => s.Id==id).FirstAsync();
    }

    public async Task NewSection(Section section)
    {
        await _dataBase.AddAsync(section);
        await _dataBase.SaveChangesAsync();
    }

    public async Task ChangeName(short id, string name)
    {
        var changed = await _dataBase.Sections.Where(s => s.Id == id).FirstAsync();
        changed.Name = name;
        await _dataBase.SaveChangesAsync();
    }
}