using ISP.BLL.Constants;
using ISP.BLL.DTOs.Auth;
using ISP.BLL.DTOs.ISP.Employee;
using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.BLL.Exceptions;
using ISP.BLL.Interfaces.Auth;
using ISP.BLL.Interfaces.ISP;
using ISP.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ISP.BLL.Services.Auth;

public class EmployeeAuthService(
    UserManager<IdentityUser> userManager,
    ITokenService tokenService,
    IUserEmployeeRepository userEmployeeRepository,
    IIspService<GetEmployeeDto, AddEmployeeDto, UpdateEmployeeDto, EmployeeFilterParameters> employeeService,
    IIspService<GetEmployeePositionDto, AddEmployeePositionDto, UpdateEmployeePositionDto, EmployeePositionFilterParameters> employeePositionService)
    : IEmployeeAuthService
{
    public async Task<LoginEmployeeResponseDto> LoginAsync(LoginRequestDto dto)
    {
        var identityUser = await userManager.FindByNameAsync(dto.UserName);
        if (identityUser is null)
        {
            throw new AuthException("Invalid username.");
        }
            
        var checkResult = await userManager.CheckPasswordAsync(identityUser, dto.Password);
        if (!checkResult)
        {
            throw new AuthException("Invalid password.");
        }

        var userRole = await EnsureValidRoleAsync(identityUser);
        var employeeId = await userEmployeeRepository.GetEmployeeIdByUserIdAsync(identityUser.Id);
        var jwtToken = tokenService.CreateJwtToken(identityUser, userRole, employeeId);
            
        return new LoginEmployeeResponseDto
        {
            UserId = identityUser.Id,
            EmployeeId = employeeId,
            UserName = dto.UserName,
            Role = userRole,
            Token = jwtToken,
        };
    }

    public async Task<RegisterEmployeeResponseDto> RegisterAsync(RegisterEmployeeRequestDto dto)
    {
        var user = new IdentityUser
        {
            UserName = dto.UserName,
        };
            
        var identityResult = await userManager.CreateAsync(user, dto.Password);
        if (!identityResult.Succeeded)
        {
            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            throw new AuthException($"Failed to create user. Errors: {errors}");
        }

        var role = await GetRoleByEmployeeAsync(dto.EmployeeId);
        identityResult = await userManager.AddToRoleAsync(user, role);
        if (!identityResult.Succeeded)
        {
            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
            throw new AuthException($"Failed to add user role. Errors: {errors}");
        }

        await userEmployeeRepository.AddUserEmployeeAsync(user.Id, dto.EmployeeId.ToString());
            
        return new RegisterEmployeeResponseDto
        {
            UserId = user.Id,
            EmployeeId = dto.EmployeeId.ToString(),
            UserName = dto.UserName,
            Role = role,
        };
    }
    
    public async Task DeleteAsync(string employeeId)
    {
        var userId = await userEmployeeRepository.GetUserIdByEmployeeIdAsync(employeeId);
        var identityUser = await userManager.FindByIdAsync(userId);
        
        if (identityUser is null)
        {
            throw new AuthException("No user found.");
        }

        await userManager.DeleteAsync(identityUser);
    }

    private async Task<string> GetRoleByEmployeeAsync(int employeeId)
    {
        var employee = await employeeService.GetByIdAsync(employeeId);
        var employeePosition = await employeePositionService.GetByIdAsync(employee.EmployeePositionId);
        return IspRoles.PositionsRoles[employeePosition.EmployeePositionName];
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