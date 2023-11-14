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

    public List<Product> GetProductsByBrand(Brand brand)
    {
        return _dbContext.Products
            .Where(p => p.Brand == brand)
            .ToList();
    }

    public List<ProductVariant> GetProductVariantsByProduct(Product product)
    {
        return _dbContext.ProductVariants
            .Include(p => p.Product)
            .Include(p=>p.Color)
            .Where(p => p.Product == product)
            .ToList();
    }

    public Dictionary<Brand,int> GetBrandProdNum()
    {
        var brands = _dbContext.Brands.Include(b => b.Products).ToList();
        Dictionary<Brand, int> result = new Dictionary<Brand, int>();
        foreach (var b in brands)
        {
            result.Add(b,b.Products.Count);
        }
        return result;
    }
    public List<Product> GetProdForCategory(Category category,Section section)
    {
        return _dbContext.Products
            .Include(p => p.Category)
            .Where(p => p.Category == category && p.Category.Sections.Contains(section)).ToList();
    }

    public List<Order> CmplOrderByProd(Product prod)
    {
        return _dbContext.OrderItems
            .Include(o => o.Order)
                .ThenInclude(o=>o.User)
            .Include(o => o.ProductVariant)
            .Where(o => o.ProductVariant.Product == prod && o.Order.status==Status.Completed)
            .Select(o=>o.Order)
            .ToList();
    }

    public List<Review> ReviewsByProd(Product prod)
    {
        return _dbContext.Reviews.Where(r => r.Product == prod).ToList();
    }

    public void UpdateUserName(User user, string username)
    {
        _dbContext.Entry(user).State = EntityState.Detached;
        user.Username = username;
        _dbContext.Attach(user);
        _dbContext.Entry(user).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }
   
    

    public List<User> GetUsers()
    {
        return _dbContext.Users.ToList();
    }

    public User? GetUserById(long id)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == id);
    }
    public List<Section> GetSections()
    {
        return _dbContext.Sections.ToList();
    }

    public List<Category> GetCategories()
    {
        return _dbContext.Categories
            .Include(c => c.Sections)
            .ToList();
    }

    public List<Brand> GetBrands()
    {
        return _dbContext.Brands.ToList();
    }
    
}