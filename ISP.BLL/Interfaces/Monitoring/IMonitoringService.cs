using System.Security.Claims;

namespace ISP.BLL.Interfaces.Monitoring;

public interface IMonitoringService
{
    Task LogActivityAsync(ClaimsPrincipal user, string tableName, string action, string details);
}