using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;



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
        var user = await _userService.GetUserById(id);
        return Ok(user.Adapt<UserDto>());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser([FromRoute]int id,[FromBody]User newUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _userService.UpdateUser(id, newUser);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _userService.AddUser(user);
        return Ok();
    }
}