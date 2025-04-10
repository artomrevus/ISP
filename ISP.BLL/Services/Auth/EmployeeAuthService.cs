using System.Linq.Expressions;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.Auth;
using ISP.BLL.Exceptions;
using ISP.BLL.Interfaces.Auth;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ISP.BLL.Services.Auth;

public class EmployeeAuthService(
    UserManager<IdentityUser> userManager,
    ITokenService tokenService,
    IUserEmployeeResolver userEmployeeResolver)
    : IEmployeeAuthService
{
    public async Task<LoginEmployeeResponseDto> LoginAsync(LoginRequestDto entity)
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

        var userRole = await EnsureValidRoleAsync(identityUser);
        var employeeId = await userEmployeeResolver.GetEmployeeIdByUserIdAsync(identityUser.Id);
        var jwtToken = tokenService.CreateJwtToken(identityUser, userRole, employeeId);
            
        return new LoginEmployeeResponseDto
        {
            UserId = identityUser.Id,
            EmployeeId = employeeId,
            UserName = entity.UserName,
            Role = userRole,
            Token = jwtToken,
        };
    }

    private async Task<string> EnsureValidRoleAsync(IdentityUser identityUser)
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

        var userRole = userRoles.Single();
        if (!IspRoles.EmployeeRoles().Contains(userRole))
        {
            throw new AuthException($"Invalid role selected. User with this username and password has the role: {userRoles.Single()}.");
        }
        
        return userRole;
    }
}