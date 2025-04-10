using ISP.BLL.DTOs.Auth;
using ISP.BLL.Interfaces.Auth;
using ISP.BLL.Interfaces.Monitoring;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IAdminAuthService adminAuthService,
    IEmployeeAuthService employeeAuthService,
    IMonitoringService monitoringService) : ControllerBase
{
    [HttpPost]
    [Route("login/admin")]
    public async Task<IActionResult> LoginAdmin([FromBody] LoginRequestDto loginRequestDto)
    {
        var responseDto = await adminAuthService.LoginAsync(loginRequestDto);
        
        await monitoringService.LogActivityAsync(
            responseDto.UserId,
            null,
            responseDto.UserName,
            responseDto.Role,
            "Auth",
            "Login", 
            "Admin logged in.");
        
        return Ok(responseDto);
    }
    
    [HttpPost]
    [Route("login/employee")]
    public async Task<IActionResult> LoginEmployee([FromBody] LoginRequestDto loginRequestDto)
    {
        var responseDto = await employeeAuthService.LoginAsync(loginRequestDto);
        
        await monitoringService.LogActivityAsync(
            responseDto.UserId,
            responseDto.EmployeeId,
            responseDto.UserName,
            responseDto.Role,
            "Auth",
            "Login", 
            "Employee logged in.");
        
        return Ok(responseDto);
    }
}