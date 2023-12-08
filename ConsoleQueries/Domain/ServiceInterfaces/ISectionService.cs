using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.ServiceInterfaces;

public interface ISectionService
{
    Task<IEnumerable<Section>> GetSections();
    Task<Section> GetSectionById(int id);
    Task NewSection(Section section);
    Task ChangeName(short id,string name);
}