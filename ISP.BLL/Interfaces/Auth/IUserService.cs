using System.Security.Claims;

namespace ISP.BLL.Interfaces.Auth;

public interface IUserService
{
    string? GetEmployeeId(ClaimsPrincipal user);
    
    string GetUserId(ClaimsPrincipal user);
    
    string GetUserName(ClaimsPrincipal user);
    
    string GetRole(ClaimsPrincipal user);
}