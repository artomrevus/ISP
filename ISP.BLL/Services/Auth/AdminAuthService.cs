using ISP.BLL.Constants;
using ISP.BLL.DTOs.Auth;
using ISP.BLL.Exceptions;
using ISP.BLL.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;

namespace ISP.BLL.Services.Auth;

public class AdminAuthService(
    UserManager<IdentityUser> userManager,
    ITokenService tokenService) 
    : IAdminAuthService
{
    public async Task<LoginAdminResponseDto> LoginAsync(LoginRequestDto entity)
    {
        var identityUser = await userManager.FindByNameAsync(entity.UserName);
        if (identityUser is null)
        {
            throw new AuthException("Invalid username.");
        }
            
        var checkResult = await userManager.CheckPasswordAsync(identityUser, entity.Password);
        if (!checkResult)
        {
            throw new AuthException("Invalid password.");
        }

        await EnsureValidRoleAsync(identityUser);
        var jwtToken = tokenService.CreateJwtToken(identityUser, IspRoles.Admin);
            
        return new LoginAdminResponseDto
        {
            UserId = identityUser.Id,
            UserName = entity.UserName,
            Role = IspRoles.Admin,
            Token = jwtToken,
        };
    }

    private async Task EnsureValidRoleAsync(IdentityUser identityUser)
    {
        var userRoles = await userManager.GetRolesAsync(identityUser);
        
        if (userRoles is null || userRoles.Count == 0)
        {
            throw new AuthException($"No role assigned to user with username '{identityUser.UserName}'.");
        }
        
        if (userRoles is null || userRoles.Count > 1)
        {
            throw new AuthException($"User with '{identityUser.UserName}' has more than one role assigned.");
        }
        
        if (userRoles.Single() != IspRoles.Admin)
        {
            throw new AuthException($"Invalid role selected. User with this username and password has the role: {userRoles.Single()}.");
        }
    }
}