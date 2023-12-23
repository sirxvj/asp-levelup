namespace ConsoleQueries.Api.DTOs;

public record CartItemDto(
    long ProductVariantId,
    int UserId,
    int Quantity
    );