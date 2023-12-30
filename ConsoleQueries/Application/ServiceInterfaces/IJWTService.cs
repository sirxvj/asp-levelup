using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IJWTService
{
    string Authenticate(UserFormDto userForm);
}