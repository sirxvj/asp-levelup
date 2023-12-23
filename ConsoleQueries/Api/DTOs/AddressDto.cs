using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record AddressDto(
    long Id,
    string Address1,
    string? City,
    string? Country,
    long? UserId
    );
    
public class AddressValidator : AbstractValidator<AddressDto>
{
    public AddressValidator()
    {
        RuleFor(x => x.Address1).NotNull().NotEmpty().Length(2,30);
        RuleFor(x => x.City).NotNull().NotEmpty().Length(2,20);
        RuleFor(x => x.Country).NotNull().NotEmpty().Length(2,20);
        RuleFor(x => x.UserId).NotNull().GreaterThan(0);
    }
}