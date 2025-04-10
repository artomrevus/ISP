using System.Security.Claims;
using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.Monitoring;

namespace ISP.BLL.Interfaces.Monitoring;

public interface IMonitoringService
{
    Task LogActivityAsync(ClaimsPrincipal user, string actionOn, string action, string details);
    
    Task LogActivityAsync(
        string userId,
        string? employeeId,
        string userName,
        string role,
        string actionOn,
        string action,
        string details);
    
    Task<IEnumerable<UserActivityDto>> GetUserActivitiesAsync(
        ClaimsPrincipal user,
        PaginationParameters pagination, 
        UserActivityFilterParameters filter);

    Task<long> GetCountAsync(
        ClaimsPrincipal user,
        UserActivityFilterParameters filter);
}