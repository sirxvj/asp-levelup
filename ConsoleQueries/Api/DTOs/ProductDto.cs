using ConsoleQueries.Domain.Entities;
using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record ProductDto(
    long Id,
    string Name,
    int Price,
    int BrandId,
    int CategoryId,
    short? AverageRating);
    
    
public class ProductValidator : AbstractValidator<ProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.BrandId).NotNull().NotEmpty();
        RuleFor(x => x.CategoryId).NotNull().NotEmpty();
        RuleFor(x => x.Name).Length(2, 50);
        RuleFor(x => x.Price).NotNull().GreaterThan(0);
        RuleFor(x => x.AverageRating).InclusiveBetween((short)0,(short)50);
    }
}