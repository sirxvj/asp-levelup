using System.Reflection;
using ConsoleQueries;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Application.Services;
using ConsoleQueries.Data;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Data.Repository;
using ConsoleQueries.Domain;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Middleware;
using ConsoleQueries.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

ConfigureServices configureServices = new ConfigureServices(builder.Services);
configureServices.Configure();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSwagger(); 
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();