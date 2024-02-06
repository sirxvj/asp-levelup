using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/")]
[ApiController]
public class HomeController:ControllerBase
{
    [HttpGet]
    public ContentResult Index()
    {
        var html = System.IO.File.ReadAllText(@"./forms.html");
        return base.Content(html, "text/html");
    }
}