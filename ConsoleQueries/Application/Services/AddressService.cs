using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class AddressService:IAddressService
{
    private readonly DataBaseContext _dbc;

    public AddressService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<AddressDto> GetById(int id)
    {
        return (await _dbc.Addresses.Where(a => a.Id == id).FirstAsync()).Adapt<AddressDto>();
    }

    public async Task AddAddress(AddressDto address)
    {
        _dbc.Add(address);
        await _dbc.SaveChangesAsync();
    }
}