using ISP.BLL.DTOs.Monitoring;
using ISP.DAL.Entities;

namespace ISP.BLL.Mappers;

public static class UserActivityMapper
{
    public static UserActivityDto ToDto(this UserActivity activity)
    {
        return new UserActivityDto
        {
            UserId = activity.UserId,
            EmployeeId = activity.EmployeeId,
            UserName = activity.UserName,
            Role = activity.Role,
            ActionOn = activity.ActionOn,
            Action = activity.Action,
            Timestamp = activity.Timestamp,
            Details = activity.Details,
        };
    }
    
    public static IEnumerable<UserActivityDto> ToDtos(this IEnumerable<UserActivity> activities)
    {
        return activities.Select(x => x.ToDto());
    } 

}