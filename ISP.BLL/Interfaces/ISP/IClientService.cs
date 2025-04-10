using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.ISP.Client;

namespace ISP.BLL.Interfaces.ISP;

public interface IClientService
{
    Task<IEnumerable<GetClientDto>> GetAllAsync(
        PaginationParameters pagination, 
        ClientFilterParameters filter, 
        SortingParameters sorting);
    
    Task<GetClientDto> GetByIdAsync(int id);
    
    Task<GetClientDto> AddAsync(AddClientDto dto);
    
    Task<GetClientDto> UpdateAsync(UpdateClientDto dto);
    
    Task DeleteAsync(int id);
    
    Task<int> GetCountAsync(ClientFilterParameters filter);
}