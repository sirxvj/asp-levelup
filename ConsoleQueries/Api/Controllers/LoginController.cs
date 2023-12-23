using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api")]
[ApiController]
public class LoginController:ControllerBase
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/registration")]
    public async Task Registration([FromBody]UserDto user)
    {
        await _userService.AddUser(user);
    }
}