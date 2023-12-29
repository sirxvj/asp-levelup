using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record SizeDto(
    int Id,
    string Name
    );
    
public class SizeValidator : AbstractValidator<SizeDto>
{
    public SizeValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().Length(2,50);
    }
}