using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record ColorDto(
    int Id,
    string Name
    );
    
public class ColorValidator : AbstractValidator<ColorDto>
{
    public ColorValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().Length(2,50);
    }
}