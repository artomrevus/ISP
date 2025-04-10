using ISP.BLL.DTOs.Filtering;
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
    [HttpGet]
    public async Task<IActionResult> GetUserActivities(
        [FromQuery] PaginationParameters pagination,
        [FromQuery] UserActivityFilterParameters filter)
    {
        var userActivities = await monitoringService.GetUserActivitiesAsync(User, pagination, filter);
        
        await monitoringService.LogActivityAsync(
            User,
            "UserActivity",
            "Monitoring", 
            $"Retrieved user activities records ({userActivities.Count()}).");
        
        return Ok(userActivities);
    }
    
    [Authorize]
    [HttpGet("count")]
    public async Task<IActionResult> GetCount([FromQuery] UserActivityFilterParameters filter)
    {
        var count = await monitoringService.GetCountAsync(User, filter);
        
        await monitoringService.LogActivityAsync(
            User,
            "UserActivity",
            "Monitoring", 
            $"Retrieved user activities count ({count}).");
        
        return Ok(count);
    }
}