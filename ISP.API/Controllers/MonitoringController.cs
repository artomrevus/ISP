using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.Monitoring;
using ISP.BLL.Interfaces.Monitoring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MonitoringController(
    IMonitoringService monitoringService) 
    : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> LogActivity(AddUserActivityDto dto)
    {
        await monitoringService.LogActivityAsync(User, dto.ActionOn, dto.Action, dto.Details);
        return Ok();
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetUserActivities(
        [FromQuery] PaginationParameters pagination,
        [FromQuery] UserActivityFilterParameters filter)
    {
        var userActivities = await monitoringService.GetUserActivitiesAsync(User, pagination, filter);
        return Ok(userActivities);
    }
    
    [Authorize]
    [HttpGet("count")]
    public async Task<IActionResult> GetCount([FromQuery] UserActivityFilterParameters filter)
    {
        var count = await monitoringService.GetCountAsync(User, filter);
        return Ok(count);
    }
}