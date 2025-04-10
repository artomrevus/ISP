using System.Security.Claims;
using ISP.BLL.Constants;
using ISP.BLL.Interfaces.Auth;

namespace ISP.BLL.Services.Auth;

public class UserService : IUserService
{
    public string? GetEmployeeId(ClaimsPrincipal user)
    {
        return user.FindFirst(IspAuthClaims.EmployeeId)?.Value;
    }
    
    public string GetUserId(ClaimsPrincipal user)
    {
        return user.FindFirst(IspAuthClaims.UserId)?.Value!;
    }

    public string GetUserName(ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)?.Value!;
    }

    public string GetRole(ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Role)?.Value!;
    }
}