using ConsoleQueries;
using ConsoleQueries.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices.Configure(builder);

var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseSwagger(); 
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();