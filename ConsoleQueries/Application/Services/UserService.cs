using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Application.ServiceInterfaces;
using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Application.Services;

public class UserService:IUserService
{
    private readonly DataBaseContext _dbc;

    public UserService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }
        
    public async Task<UserDto> GetUserById(int id)
    {
        return (await _dbc.Users.Where(u => u.Id == id).FirstOrDefaultAsync()).Adapt<UserDto>();
    }

    public async Task UpdateUser(int id, UserDto user)
    {
        var edited = await _dbc.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        if(edited is not null)
            _dbc.Entry(edited).CurrentValues.SetValues(new
                { user.Username, type = user.Type, user.Phone, user.Email, user.FirstName, user.LastName });
        await _dbc.SaveChangesAsync();
    }

    public async Task AddUser(RegistrationFormDto user)
    {
        var newUser = user.Adapt<User>();
        _dbc.Users.Add(newUser);
        await _dbc.SaveChangesAsync();
    }
}