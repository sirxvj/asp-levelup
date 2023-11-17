using ConsoleQueries.Data;
using ConsoleQueries.Models;
using ConsoleQueries.Queries;
using Microsoft.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>();
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