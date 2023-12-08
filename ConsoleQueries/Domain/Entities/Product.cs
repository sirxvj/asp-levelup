using ConsoleQueries.Models;
using FluentValidation;

namespace ConsoleQueries.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Price { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public short? AverageRating { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Media> Media { get; set; } = new List<Media>();
        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.BrandId).NotNull().NotEmpty();
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            RuleFor(x => x.Name).Length(2, 50);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.AverageRating).InclusiveBetween((short)0,(short)50);
        }
    }
}
