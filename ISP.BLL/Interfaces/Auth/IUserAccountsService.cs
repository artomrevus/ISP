using ISP.BLL.DTOs.Auth;

namespace ISP.BLL.Interfaces.Auth;

public interface IUserAccountsService
{
    Task<IEnumerable<UserAccountDto>> GetAllAsync();
}