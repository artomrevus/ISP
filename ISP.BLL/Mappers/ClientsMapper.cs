using ISP.BLL.DTOs.ISP.Client;
using ISP.DAL.Entities;

namespace ISP.BLL.Mappers;

public static class ClientsMapper
{
    public static GetClientDto ToGetClientDto(this Client client)
    {
        return new GetClientDto
        {
            Id = client.Id,
            ClientStatusId = client.ClientStatusId,
            LocationId = client.LocationId,
            FirstName = client.FirstName,
            LastName = client.LastName,
            PhoneNumber = client.PhoneNumber,
            Email = client.Email,
            RegistrationDate = client.RegistrationDate,
        };
    }
    
    public static IEnumerable<GetClientDto> ToGetClientDtos(this IEnumerable<Client> clients)
    {
        return clients.Select(x => x.ToGetClientDto());
    } 

    public static Client ToClient(this AddClientDto addClientDto)
    {
        return new Client
        {
            ClientStatusId = addClientDto.ClientStatusId,
            LocationId = addClientDto.LocationId,
            FirstName = addClientDto.FirstName,
            LastName = addClientDto.LastName,
            PhoneNumber = addClientDto.PhoneNumber,
            Email = addClientDto.Email,
            RegistrationDate = addClientDto.RegistrationDate,
        };
    }
    
    public static Client ToClient(this UpdateClientDto updateClientDto)
    {
        return new Client
        {
            Id = updateClientDto.Id,
            ClientStatusId = updateClientDto.ClientStatusId,
            LocationId = updateClientDto.LocationId,
            FirstName = updateClientDto.FirstName,
            LastName = updateClientDto.LastName,
            PhoneNumber = updateClientDto.PhoneNumber,
            Email = updateClientDto.Email,
            RegistrationDate = updateClientDto.RegistrationDate,
        };
    }
}