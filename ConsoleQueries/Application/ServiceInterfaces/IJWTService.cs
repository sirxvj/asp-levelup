using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IJWTService
{
    Task<string> Authenticate(UserFormDto userForm);
}