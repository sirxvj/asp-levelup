using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Api.DTOs;

public record RegistrationFormDto(
    string Username, 
    string Phone,
    string Email,
    string FirstName,
    string LastName,
    UserType type,
    string Password
    );