using Microsoft.AspNetCore.Identity;

namespace ISP.BLL.Interfaces.Auth;

public interface ITokenService
{
    string CreateJwtToken(IdentityUser user, string role);

    string CreateJwtToken(IdentityUser user, string role, string employeeId);
}