using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface ISectionService
{
    Task<IEnumerable<SectionDto>> GetSections();
    Task<SectionDto> GetSectionById(int id);
    Task AddSection(SectionDto section);
    Task ChangeName(short id,string name);
}