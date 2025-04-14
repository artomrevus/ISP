using System.Security.Claims;
using ISP.BLL.DTOs.Filtering;
using ISP.BLL.DTOs.Monitoring;

namespace ISP.BLL.Interfaces.Monitoring;

public interface IMonitoringService
{
    Task LogActivityAsync(ClaimsPrincipal user, string actionOn, string action, string details);
    
    Task<IEnumerable<GetUserActivityDto>> GetUserActivitiesAsync(
        ClaimsPrincipal user,
        PaginationParameters pagination, 
        UserActivityFilterParameters filter);

    Task<long> GetCountAsync(
        ClaimsPrincipal user,
        UserActivityFilterParameters filter);
}