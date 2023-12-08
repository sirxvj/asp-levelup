namespace ConsoleQueries.Api.DTOs;

public record ProductDto(
    long Id,
    string Name,
    int? Price,
    int? BrandId,
    int? CategoryId,
    short? AverageRating);