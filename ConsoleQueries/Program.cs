using System.Reflection;
using ConsoleQueries.Data;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Data.Repository;
using ConsoleQueries.Domain;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Domain.Services;
using ConsoleQueries.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSwagger(); 
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();