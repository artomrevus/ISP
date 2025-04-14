using ISP.BLL.DTOs.Auth;
using ISP.BLL.Interfaces.Auth;
using ISP.BLL.Interfaces.Monitoring;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAdminAuthService adminAuthService, IEmployeeAuthService employeeAuthService) : ControllerBase
{
    [HttpPost]
    [Route("login/admin")]
    public async Task<IActionResult> LoginAdmin([FromBody] LoginRequestDto loginRequestDto)
    {
        var responseDto = await adminAuthService.LoginAsync(loginRequestDto);
        return Ok(responseDto);
    }
    
    [HttpPost]
    [Route("login/employee")]
    public async Task<IActionResult> LoginEmployee([FromBody] LoginRequestDto loginRequestDto)
    {
        var responseDto = await employeeAuthService.LoginAsync(loginRequestDto);
        return Ok(responseDto);
    }
}