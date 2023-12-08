using ConsoleQueries.Data.DataBase;
using ConsoleQueries.Domain.ServiceInterfaces;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Domain.Services;

public class UserService:IUserService
{
    private readonly DataBaseContext _dbc;

    public UserService(DataBaseContext dbc)
    {
        _dbc = dbc;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _dbc.Users.Where(u => u.Id == id).FirstAsync();
    }

    public async Task UpdateUser(int id, User user)
    {
        var edited = await _dbc.Users.Where(u => u.Id == id).FirstAsync();
        _dbc.Entry(edited).CurrentValues.SetValues(new { user.Username,user.type,user.Phone,user.Email,user.FirstName,user.LastName });
        await _dbc.SaveChangesAsync();
    }

    public async Task AddUser(User user)
    {
        await _dbc.Users.AddAsync(user);
        await _dbc.SaveChangesAsync();
    }
}