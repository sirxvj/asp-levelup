using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleQueries.Api.Controllers;

[Authorize]
[Route("/api/[controller]")]
[ApiController]
public class AddressController:ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AddressDto>> GetAddressById([FromRoute]int id) 
    {
        return Ok(await _addressService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddAddress([FromBody]AddressDto address)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _addressService.AddAddress(address);
        return Ok();
    }
}