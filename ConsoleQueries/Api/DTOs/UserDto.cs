using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;
using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record UserDto(
    int Id,
    string Username,
    string Phone,
    string Email,
    string FirstName,
    string LastName,
    UserType Type
    );
 public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Phone).NotNull().Length(8,20);
            RuleFor(x => x.Username).NotNull().Length(2, 30);
            RuleFor(x => x.Email).NotNull().Length(3, 30);
            RuleFor(x => x.FirstName).NotNull().Length(2, 30);
            RuleFor(x => x.LastName).NotNull().Length(2, 30);
        }
    }