using ConsoleQueries.Data;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Domain.Services;

public class CategoryService:ICategoryService
{
    private readonly DataBaseContext _dbc;

    public CategoryService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _dbc.Categories.ToListAsync();
    }

    public async Task AddCategory(Category category)
    {
        await _dbc.AddAsync(category);
        await _dbc.SaveChangesAsync();
    }

    public async Task PutToSection(int cId,int sId)
    {
        var sec =  await _dbc.Sections.FirstAsync(s => s.Id == sId);
        var cat = await _dbc.Categories.FirstAsync(c => c.Id == cId);
        cat.Sections.Add(sec);
        await _dbc.SaveChangesAsync();
    }

    public async Task PutParentCategory(int cId, int pId)
    {
        var category = await _dbc.Categories.FirstAsync(c => c.Id == cId);
        category.ParentCategoryId = pId;
        await _dbc.SaveChangesAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await _dbc.Categories.FirstAsync(c => c.Id == id);
    }
}