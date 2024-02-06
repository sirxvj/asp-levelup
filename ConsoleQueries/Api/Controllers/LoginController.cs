using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class LoginController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJWTService _jwtService;
    public LoginController(IUserService userService, IJWTService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }
    [AllowAnonymous]
    [HttpPost]
    [Route("auth")]
    public async Task<IActionResult> Authenticate([FromBody]UserFormDto userForm)
    {
        var token = await _jwtService.Authenticate(userForm);
        if (token == String.Empty)
        {
            return Unauthorized();
        }
        return Ok(token);
    }
    
    [HttpPost("registration")]
    public async Task<ActionResult> Registration([FromBody]RegistrationFormDto user)
    {
        await _userService.AddUser(user);
        return Ok();
    }
}