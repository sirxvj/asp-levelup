using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class LoginController:ControllerBase
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("/registration")]
    public async Task<ActionResult> Registration([FromBody]UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _userService.AddUser(user);
        return Ok();
    }
}