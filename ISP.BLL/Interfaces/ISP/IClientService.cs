using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Client;

namespace ISP.BLL.Interfaces.ISP;

public interface IClientService
{
    Task<IEnumerable<GetClientDto>> GetAllClientsAsync(
        PaginationParameters pagination, 
        ClientFilterParameters filter, 
        SortingParameters sorting);
    
    Task<GetClientDto> GetClientByIdAsync(int id);
    
    Task<GetClientDto> AddClientAsync(AddClientDto getClientDto);
    
    Task<GetClientDto> UpdateClientAsync(UpdateClientDto getClientDto);
    
    Task DeleteClientAsync(int id);
    
    Task<int> GetTotalCountAsync(string? searchTerm = null);
}