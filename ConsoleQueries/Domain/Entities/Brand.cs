using System.ComponentModel.DataAnnotations;
using ConsoleQueries.Models;
using FluentValidation;

namespace ConsoleQueries.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Name).Length(2, 50);
        }
    }
}

