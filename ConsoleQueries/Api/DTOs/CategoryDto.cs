using ConsoleQueries.Domain.Entities;
using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record CategoryDto(
    int Id,
    string Name,
    int? ParentCategoryId);
    
public class CategoryValidator : AbstractValidator<CategoryDto>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Name).Length(2, 50);
    }
}