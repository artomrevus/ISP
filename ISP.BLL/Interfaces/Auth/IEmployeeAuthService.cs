using ISP.BLL.DTOs.Auth;

namespace ISP.BLL.Interfaces.Auth;

public interface IEmployeeAuthService
{
    Task<LoginEmployeeResponseDto> LoginAsync(LoginRequestDto dto);
    
    Task<RegisterEmployeeResponseDto> RegisterAsync(RegisterEmployeeRequestDto dto);
    
    Task DeleteAsync(string employeeId);
}