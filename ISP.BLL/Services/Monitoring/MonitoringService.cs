using System.Security.Claims;
using AutoMapper;
using ISP.BLL.Constants;
using ISP.BLL.DTOs.ISP;
using ISP.BLL.DTOs.Monitoring;
using ISP.BLL.Interfaces.Auth;
using ISP.BLL.Interfaces.Monitoring;
using ISP.BLL.Mappers;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;
using MongoDB.Driver;

namespace ISP.BLL.Services.Monitoring;

public class MonitoringService(
    IUserActivityRepository activityRepository,
    IUnitOfWork unitOfWork,
    IUserService userService,
    IMapper mapper) : IMonitoringService
{
    public async Task LogActivityAsync(ClaimsPrincipal user, string actionOn, string action, string details)
    {
        var employeeId = userService.GetEmployeeId(user);
        var userId = userService.GetUserId(user);
        var userName = userService.GetUserName(user);
        var role = userService.GetRole(user);
        
        var activity = new UserActivity
        {
            UserId = userId,
            EmployeeId = employeeId,
            UserName = userName,
            Role = role,
            ActionOn = actionOn,
            Action = action,
            Timestamp = DateTime.Now,
            Details = details,
        };

        await activityRepository.AddAsync(activity);
    }

    public async Task<IEnumerable<GetUserActivityDto>> GetUserActivitiesAsync(
        ClaimsPrincipal user,
        PaginationParameters pagination,
        UserActivityFilterParameters filter)
    {
        var userId = userService.GetUserId(user);
        var userRole = userService.GetRole(user);
        
        var skipRecords = (pagination.PageNumber - 1) * pagination.PageSize;
        var takeRecords = pagination.PageSize;
        var filterDefinition = await BuildFilterAsync(userId, userRole, filter);
        var sortBy = Builders<UserActivity>.Sort.Descending(a => a.Timestamp);

        var activities = await activityRepository.GetAsync(
            skipRecords,
            takeRecords,
            filterDefinition,
            sortBy);
        
        return mapper.Map<IEnumerable<GetUserActivityDto>>(activities);
    }
    
    public async Task<long> GetCountAsync(
        ClaimsPrincipal user,
        UserActivityFilterParameters filter)
    {
        var userId = userService.GetUserId(user);
        var userRole = userService.GetRole(user);
        
        var filterExpression = await BuildFilterAsync(userId, userRole, filter);
        return await activityRepository.CountAsync(filterExpression);
    }

    private async Task<FilterDefinition<UserActivity>> BuildFilterAsync(
        string userId,
        string userRole, 
        UserActivityFilterParameters filter)
    {
        var filterDefinition  = Builders<UserActivity>.Filter.Empty; 
        
        if (userRole == IspRoles.OfficeManager)
        {
            var roleFilter = Builders<UserActivity>.Filter.Where(x => 
                x.Role == IspRoles.HumanResource || 
                x.Role == IspRoles.NetworkTechnician || 
                x.Role == IspRoles.WarehouseWorker || 
                (x.Role == IspRoles.OfficeManager && x.UserId == userId)
            );
            
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, roleFilter);
        }
        
        if (userRole is IspRoles.HumanResource or IspRoles.NetworkTechnician or IspRoles.WarehouseWorker)
        {
            var roleFilter = Builders<UserActivity>.Filter.Where(x => 
                (x.Role == IspRoles.HumanResource || 
                x.Role == IspRoles.NetworkTechnician || 
                x.Role == IspRoles.WarehouseWorker) && 
                x.UserId == userId
            );
            
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, roleFilter);
        }
        
        if (filter.EmployeeId.HasValue)
        {
            var employeeFilter = Builders<UserActivity>.Filter.Eq(x => x.EmployeeId, filter.EmployeeId.Value.ToString());
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, employeeFilter);
        }
        
        if (filter.EmployeeOfficeId.HasValue)
        {
            var employeesRepository = unitOfWork.Repository<Employee>();
            var officeEmployees = await employeesRepository.GetAsync(
                null,
                null,
                x => x.OfficeId == filter.EmployeeOfficeId.Value
            );
            
            var officeEmployeeIds = officeEmployees.Select(x => x.Id.ToString()).ToList();
            
            var officeFilter = Builders<UserActivity>.Filter.Where(x => 
                x.EmployeeId != null && officeEmployeeIds.Contains(x.EmployeeId));
            
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, officeFilter);
        }
        
        if (!string.IsNullOrEmpty(filter.UserNameContains))
        {
            var userNameFilter = Builders<UserActivity>.Filter.Where(x =>
                x.UserName.ToLower().Contains(filter.UserNameContains.ToLower()));
            
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, userNameFilter);
        }
        
        if (!string.IsNullOrEmpty(filter.RoleContains))
        {
            var roleFilter = Builders<UserActivity>.Filter.Where(x =>
                x.Role.ToLower().Contains(filter.RoleContains.ToLower()));
            
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, roleFilter);
        }
        
        if (!string.IsNullOrEmpty(filter.ActionOnContains))
        {
            var actionOnFilter = Builders<UserActivity>.Filter.Where(x =>
                x.ActionOn.ToLower().Contains(filter.ActionOnContains.ToLower()));
            
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, actionOnFilter);
        }
        
        if (!string.IsNullOrEmpty(filter.ActionContains))
        {
            var actionFilter = Builders<UserActivity>.Filter.Where(x =>
                x.Action.ToLower().Contains(filter.ActionContains.ToLower()));
            
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, actionFilter);
        }
        
        if (filter.StartDateTime.HasValue)
        {
            var startFilter = Builders<UserActivity>.Filter.Gte(x => x.Timestamp, filter.StartDateTime.Value);
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, startFilter);
        }

        if (filter.EndDateTime.HasValue)
        {
            var endFilter = Builders<UserActivity>.Filter.Lte(x => x.Timestamp, filter.EndDateTime.Value);
            filterDefinition = Builders<UserActivity>.Filter.And(filterDefinition, endFilter);
        }
       
        return filterDefinition;
    }
}