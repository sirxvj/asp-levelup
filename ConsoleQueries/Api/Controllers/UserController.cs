using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;


[Authorize]
[Route("/api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById([FromRoute] int id)
    {
        return Ok(await _userService.GetUserById(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser([FromRoute]int id,[FromBody]UserDto newUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _userService.UpdateUser(id, newUser);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _userService.AddUser(user);
        return Ok();
    }
}