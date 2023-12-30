using System.Text;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Application.Services;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleQueries;

public static class ConfigureServices
{
    public static void Configure(WebApplicationBuilder builder)
    {
        var config = builder.Configuration;
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = config["JWT:Issuer"],
                        ValidAudience = config["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                }
            
            ); 
        builder.Services.AddAuthorization();
        builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
 
       builder.Services.AddControllers();
       builder.Services.AddLogging(loggingBuilder =>
       {
           loggingBuilder.AddConsole();
           loggingBuilder.AddDebug();
       });
        builder.Services.AddFluentValidationAutoValidation(); 
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
        
        
        builder.Services.AddTransient<ExceptionHandlerMiddleware>();
        builder.Services.AddScoped<IBrandService,BrandService>();
        builder.Services.AddScoped<ISectionService, SectionService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IMediaService, MediaService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IReviewsService, ReviewsService>();
        builder.Services.AddSingleton<IJWTService, JwtService>();
        builder.Services.AddSwaggerGen();
    }
}