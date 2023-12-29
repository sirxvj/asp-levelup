using ConsoleQueries.Models;
using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record ReviewDto(
    long Id ,
    short Rating,
    string Title,
    string Comment, 
    long ProductId, 
    long UserId,
    DateTime Date
    );
    
public class ReviewsValidator : AbstractValidator<ReviewDto>
{
    public ReviewsValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().Length(2,50);
        RuleFor(x => x.Comment).NotNull().NotEmpty();
        RuleFor(x => x.Comment).Length(2, 2000);
        RuleFor(x => x.Rating).InclusiveBetween((short)0, (short)5);
        RuleFor(x => x.Date).InclusiveBetween(new DateTime(2023), DateTime.Now);
    }
}