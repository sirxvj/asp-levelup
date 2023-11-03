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

    public List<Product> GetProsuctsByBrand(Brand brand)
    {
        return _dbContext.Products
            .Include(p => p.Brand)
            .Where(p => p.Brand == brand)
            .ToList();
    }

    public List<ProductVariant> GetPrVarByProduct(Product product)
    {
        return _dbContext.ProductVariants
            .Include(p => p.Product)
            .Include(p=>p.Color)
            .Include(p=>p.Size)
            .Where(p => p.Product == product)
            .ToList();
    }

    public List<BrandNumber> GetBrandProdNum()
    {
        var brands = _dbContext.Brands.ToList();
        List<BrandNumber> result = new List<BrandNumber>();
        foreach (var brand in brands)
        {
            result.Add(new BrandNumber(brand,_dbContext.Products.Where(p => p.Brand == brand).Count()));
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
            .Include(o => o.ProductVariant)
            .Include(o=>o.Order.User)
            .Where(o => o.ProductVariant.Product == prod && o.Order.status==Status.Completed)
            .Select(o=>o.Order)
            .ToList();
    }

    public List<Review> ReviewsByProd(Product prod)
    {
        return _dbContext.Reviews.Where(r => r.Product == prod).ToList();
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

    public void InsertProduct(Product prod)
    {
        _dbContext.Products.Add(prod);
        _dbContext.SaveChanges();
    }

    public void InsertProductVariant(ProductVariant pv)
    {
        _dbContext.ProductVariants.Add(pv);
        _dbContext.SaveChanges();
    }

    public void InsertSize(Size size)
    {
        _dbContext.Sizes.Add(size);
        _dbContext.SaveChanges();
    }

    public void InsertColor(Color color)
    {
        _dbContext.Colors.Add(color);
        _dbContext.SaveChanges();
    }

    public List<Product> GetProducts()
    {
        return _dbContext.Products.ToList();
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