using ConsoleQueries.Models;

namespace ConsoleQueries.Api.DTOs;

public record OrderTransactionDto(
    long OrderId,
    DateTime? UpdatedAt,
    Status Status
    );