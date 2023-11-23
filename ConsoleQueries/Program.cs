using ConsoleQueries.Data;
using ConsoleQueries.Data.Repository;
using ConsoleQueries.Domain;
using ConsoleQueries.Models;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IBrandService,BrandService>();
builder.Services.AddSingleton<IBrandRepository, BrandRepositoryImpl>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brand}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brand}/{action=PutBrand}/{id?}/{name?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brand}/{action=NewBrand}/{name?}");

app.Run();