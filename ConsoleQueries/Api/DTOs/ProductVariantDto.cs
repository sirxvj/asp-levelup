using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record ProductVariantDto(
    long Id,
    int ColorId,
    int SizeId,
    long ProductId,
    int Quantity
    );
    
public class ProductVariantValidator : AbstractValidator<ProductVariantDto>
{
    public ProductVariantValidator()
    {
        RuleFor(x => x.ColorId).NotNull().NotEmpty();
        RuleFor(x => x.SizeId).NotNull().NotEmpty();
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
        RuleFor(x => x.Quantity).NotNull().GreaterThan(-1);
    }
}