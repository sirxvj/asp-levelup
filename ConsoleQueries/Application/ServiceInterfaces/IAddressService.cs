using ConsoleQueries.Api.DTOs;

namespace ConsoleQueries.Application.ServiceInterfaces;

public interface IAddressService
{
    public Task<AddressDto> GetById(int id);
    public Task AddAddress(AddressDto address);
}