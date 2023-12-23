using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAll();
    Task AddCategory(CategoryDto category);
    Task LinkToSection(int cId,int sId);

    Task PutParentCategory(int cId,int pId);
    Task<CategoryDto> GetById(int id);
}