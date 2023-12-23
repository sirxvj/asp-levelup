using FluentValidation;

namespace ConsoleQueries.Api.DTOs;

public record MediaDto(
    long ProductId,
    byte[] Bytes,
    string FileType,
    string FileName 
    );
    
public class MediaValidator : AbstractValidator<MediaDto>
{
    public MediaValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
        RuleFor(x => x.Bytes).NotNull().NotEmpty();
        RuleFor(x => x.FileType).NotNull().NotEmpty();
        RuleFor(x => x.FileName).NotNull().NotEmpty();
    }
}