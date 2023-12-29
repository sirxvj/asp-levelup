using ConsoleQueries.Domain.Entities;
using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record BrandDto(
    int Id,
    string Name
);

public class BrandValidator : AbstractValidator<BrandDto>
{
    public BrandValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Name).Length(2, 50);
    }
}