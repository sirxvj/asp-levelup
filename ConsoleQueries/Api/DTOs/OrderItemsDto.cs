namespace ConsoleQueries.Api.DTOs;

public record OrderItemsDto(
    long ProductVariantId,
    long OrderId,
    int Quantity
    );