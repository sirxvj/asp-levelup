using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class CategoryService:ICategoryService
{
    private readonly DataBaseContext _dbc;

    public CategoryService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        return (await _dbc.Categories.ToListAsync()).Adapt<IEnumerable<CategoryDto>>();
    }

    public async Task AddCategory(CategoryDto category)
    {
        _dbc.Add(category);
        await _dbc.SaveChangesAsync();
    }

    public async Task LinkToSection(int categoryId,int sectionId)
    {
        var sec =  await _dbc.Sections.FirstAsync(s => s.Id == sectionId);
        var cat = await _dbc.Categories.FirstAsync(c => c.Id == categoryId);
        cat.Sections.Add(sec);
        await _dbc.SaveChangesAsync();
    }

    public async Task PutParentCategory(int categoryId, int productId)
    {
        var category = await _dbc.Categories.FirstAsync(c => c.Id == categoryId);
        category.ParentCategoryId = productId;
        await _dbc.SaveChangesAsync();
    }

    public async Task<CategoryDto> GetById(int id)
    {
        return (await _dbc.Categories.FirstAsync(c => c.Id == id)).Adapt<CategoryDto>();
    }
}