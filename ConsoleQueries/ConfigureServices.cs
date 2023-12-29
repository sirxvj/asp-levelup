using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Application.Services;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ConsoleQueries;

public class ConfigureServices
{
    private readonly IServiceCollection _services;
    public ConfigureServices(IServiceCollection services)
    {
        _services = services;
    }

    public void Configure()
    {
       _services.AddControllers();
       _services.AddLogging(config =>
       {
           config.AddConsole();
           config.AddDebug();
       });
        _services.AddFluentValidationAutoValidation(); 
        _services.AddValidatorsFromAssemblyContaining<Program>();
        _services.AddTransient<ExceptionHandlerMiddleware>();
        _services.AddScoped<IBrandService,BrandService>();
        _services.AddScoped<ISectionService, SectionService>();
        _services.AddScoped<ICategoryService, CategoryService>();
        _services.AddScoped<IProductService, ProductService>();
        _services.AddScoped<IMediaService, MediaService>();
        _services.AddScoped<IUserService, UserService>();
        _services.AddScoped<IReviewsService, ReviewsService>();

        _services.AddSwaggerGen();
    }
}