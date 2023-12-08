using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.ServiceInterfaces;

public interface IUserService
{
    Task<User> GetUserById(int id);
    Task UpdateUser(int id, User user);
    Task AddUser(User user);
    
}