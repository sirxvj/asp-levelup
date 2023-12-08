using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.ServiceInterfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAll();
    Task AddCategory(Category category);
    Task PutToSection(int cId,int sId);

    Task PutParentCategory(int cId,int pId);
    Task<Category> GetById(int id);
}