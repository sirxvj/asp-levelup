using ConsoleQueries.Models;

namespace ConsoleQueries.Api.DTOs;

public record OrderDto(
    long Id,
    long? UserId,
    int? Price,
    long? AddressId,
    Status Status,
    DateTime? CreatedAt
    );