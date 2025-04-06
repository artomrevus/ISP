using System.Security.Claims;
using ISP.BLL.Interfaces.Monitoring;
using ISP.DAL.Data;
using ISP.DAL.Entities;

namespace ISP.BLL.Services.Monitoring;

public class MonitoringService(MongoDbContext mongoContext) : IMonitoringService
{
    public async Task LogActivityAsync(ClaimsPrincipal user, string tableName, string action, string details)
    {
        var employeeIdClaim = user.FindFirst("employeeId")?.Value;
        var employeeId = employeeIdClaim is null ? (int?)null : int.Parse(employeeIdClaim);
        var userName = user.FindFirst(ClaimTypes.Name)?.Value!;
        var role = user.FindFirst(ClaimTypes.Role)?.Value!;
        
        var activity = new UserActivity
        {
            EmployeeId = employeeId,
            UserName = userName,
            Role = role,
            TableName = tableName,
            Action = action,
            Timestamp = DateTime.Now,
            Details = details,
        };

        await mongoContext.UserActivities.InsertOneAsync(activity);
    }
}