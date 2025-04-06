using ISP.BLL.DTOs.Auth;

namespace ISP.BLL.Interfaces.Auth;

public interface IEmployeeAuthService
{
    Task<LoginEmployeeResponseDto> LoginAsync(LoginRequestDto entity);
}