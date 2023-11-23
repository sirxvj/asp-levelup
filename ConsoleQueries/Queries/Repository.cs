using ConsoleQueries.Data;
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

    public async Task<List<Product>> GetProductsByBrand(Brand brand)
    {
        return await _dbContext.Products
            .Where(p => p.Brand == brand)
            .ToListAsync();
    }

    public async Task<List<ProductVariant>> GetProductVariantsByProduct(Product product)
    {
        return await _dbContext.ProductVariants
            .Include(p => p.Product)
            .Include(p=>p.Color)
            .Where(p => p.Product == product)
            .ToListAsync();
    }

    public async Task<Dictionary<Brand,int>> GetBrandProdNum()
    {
        Dictionary<Brand, int> result = new Dictionary<Brand, int>();
        await _dbContext.Brands.Include(b => b.Products).ForEachAsync(
            b => result.Add(b, b.Products.Count)
        );
        return result;
    }
    public async Task<List<Product>> GetProdForCategory(Category category,Section section)
    {
        return await _dbContext.Products
            .Include(p => p.Category)
            .Where(p => p.Category == category && p.Category.Sections.Contains(section)).ToListAsync();
    }

    public async Task<List<Order>> CmplOrderByProd(Product prod)
    {
        return await _dbContext.OrderItems
            .Include(o => o.Order)
                .ThenInclude(o=>o.User)
            .Include(o => o.ProductVariant)
            .Where(o => o.ProductVariant.Product == prod && o.Order.status==Status.Completed)
            .Select(o=>o.Order)
            .ToListAsync();
    }

    public async Task<List<Review>> ReviewsByProd(Product prod)
    {
        return await _dbContext.Reviews.Where(r => r.Product == prod).ToListAsync();
    }

    public async Task UpdateUserName(User user, string username)
    {
        _dbContext.Entry(user).State = EntityState.Detached;
        user.Username = username;
        _dbContext.Attach(user);
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
   
    

    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(long id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<List<Section>> GetSections()
    {
        return await _dbContext.Sections.ToListAsync();
    }

    public async Task<List<Category>> GetCategories()
    {
        return await _dbContext.Categories
            .Include(c => c.Sections)
            .ToListAsync();
    }
    
    public async Task<List<Brand>> GetBrands()
    {
        return await _dbContext.Brands.ToListAsync();
    }
    
}