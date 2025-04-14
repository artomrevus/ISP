using ISP.BLL.DTOs.Filtering;

namespace ISP.BLL.Interfaces.ISP;

public interface IIspService<TGetDto, in TAddDto, in TUpdateDto, in TFilter>
{
    Task<IEnumerable<TGetDto>> GetAllAsync(
        PaginationParameters pagination, 
        TFilter filter, 
        SortingParameters sorting);
    
    Task<TGetDto> GetByIdAsync(int id);
    
    Task<TGetDto> AddAsync(TAddDto dto);
    
    Task<TGetDto> UpdateAsync(int id, TUpdateDto dto);
    
    Task DeleteAsync(int id);
    
    Task<int> GetCountAsync(TFilter filter);
}