using ConsoleQueries.Api.DTOs;
using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IUserService
{
    Task<UserDto> GetUserById(int id);
    Task UpdateUser(int id, UserDto user);
    Task AddUser(RegistrationFormDto user);
    
    
    
}