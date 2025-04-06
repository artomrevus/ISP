using ISP.BLL.DTOs.Auth;
using ISP.BLL.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IAdminAuthService adminAuthService,
    IEmployeeAuthService employeeAuthService) : ControllerBase
{
    [HttpPost]
    [Route("login/admin")]
    public async Task<IActionResult> LoginAdmin([FromBody] LoginRequestDto loginRequestDto)
    {
        var responseObj = await adminAuthService.LoginAsync(loginRequestDto);
        return Ok(responseObj);
    }
    
    [HttpPost]
    [Route("login/employee")]
    public async Task<IActionResult> LoginEmployee([FromBody] LoginRequestDto loginRequestDto)
    {
        var responseObj = await employeeAuthService.LoginAsync(loginRequestDto);
        return Ok(responseObj);
    }
}