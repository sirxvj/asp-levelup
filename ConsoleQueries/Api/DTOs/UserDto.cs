using ConsoleQueries.Models;

namespace ConsoleQueries.Api.DTOs;

public record UserDto(
    int Id,
    string? Username,
    string? Phone,
    string? Email,
    string? FirstName,
    string? LastName,
    UserType type
    );