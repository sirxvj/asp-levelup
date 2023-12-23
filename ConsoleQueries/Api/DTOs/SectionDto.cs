using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record SectionDto
(
    int Id,
    string Name
);

public class SectionValidator : AbstractValidator<SectionDto>
{
    public SectionValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Name).Length(2, 50);
    }
}