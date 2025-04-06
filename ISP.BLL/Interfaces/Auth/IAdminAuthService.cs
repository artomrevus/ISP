using ISP.BLL.DTOs.Auth;

namespace ISP.BLL.Interfaces.Auth;

public interface IAdminAuthService
{
    Task<LoginAdminResponseDto> LoginAsync(LoginRequestDto entity);
}