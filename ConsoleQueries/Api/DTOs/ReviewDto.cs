namespace ConsoleQueries.Api.DTOs;

public record ReviewDto(
long Id ,
short? Rating,
string? Titile,
string? Comment, 
long? ProductId, 
 long? UserId,
DateTime? Date
    
    );