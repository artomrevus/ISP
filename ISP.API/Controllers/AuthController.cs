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
    IUserAccountsService userAccountsService)
    : ControllerBase
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

    [HttpPost]
    [Route("register/employee")]
    public async Task<IActionResult> RegisterEmployee([FromBody] RegisterEmployeeRequestDto registerRequestDto)
    {
        var responseDto = await employeeAuthService.RegisterAsync(registerRequestDto);
        return Ok(responseDto);
    }

    [HttpDelete]
    [Route("delete/{employeeId}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] string employeeId)
    {
        await employeeAuthService.DeleteAsync(employeeId);
        return NoContent();
    }

    [HttpGet]
    [Route("accounts")]
    public async Task<IActionResult> GetAllAccounts()
    {
        var accounts = await userAccountsService.GetAllAsync();
        return Ok(accounts);
    }
}