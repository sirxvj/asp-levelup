using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Queries;

public class Repository
{
    private readonly DataBaseContext _dbContext;

    public Repository(DataBaseContext dbc)
    {
        _dbContext = dbc;
    }

    public void InsertBrand(Brand _brand)
    {
        _dbContext.Brands.Add(_brand);
        _dbContext.SaveChanges();
    }

    public void InsertSection(Section sec)
    {
        _dbContext.Sections.Add(sec);
        _dbContext.SaveChanges();
    }
    
    public void InsertCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }

    public List<Section> GetSections()
    {
        return _dbContext.Sections.ToList();
    }

    public List<Category> GetCategories()
    {
        return _dbContext.Categories
            .Include(c=>c.Sections)
            .ToList();
    }
    
    public List<Brand> GetBrands()
    {
        return _dbContext.Brands.ToList();
    }
    
}