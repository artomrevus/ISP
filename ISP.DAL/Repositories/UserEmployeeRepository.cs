using ISP.DAL.Data;
using ISP.DAL.Entities;
using ISP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Repositories;

public class UserEmployeeRepository(AuthDbContext dbContext) : IUserEmployeeRepository
{
    public async Task<string> GetEmployeeIdByUserIdAsync(string userId)
    {
        var userEmployee = await dbContext.UserEmployees
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (userEmployee is null)
        {
            throw new InvalidOperationException($"UserEmployee for user id '{userId}' not found");
        }

        return userEmployee.EmployeeId;
    }
    
    public async Task<string> GetUserIdByEmployeeIdAsync(string employeeId)
    {
        var userEmployee = await dbContext.UserEmployees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        if (userEmployee is null)
        {
            throw new InvalidOperationException($"UserEmployee for employee id '{employeeId}' not found");
        }

        return userEmployee.UserId;
    }

    public async Task AddUserEmployeeAsync(string userId, string employeeId)
    {
        var userEmployee = new UserEmployee
        {
            UserId = userId,
            EmployeeId = employeeId,
        };

        await dbContext.AddAsync(userEmployee);
        await dbContext.SaveChangesAsync();
    }
}