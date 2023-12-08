namespace ConsoleQueries.Api.DTOs;

public record CategoryDto(
int Id,
string Name,
int? ParentCategoryId
    );